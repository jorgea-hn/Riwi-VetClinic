
using System;
using VetClinic.Data;
using VetClinic.Models;
using VetClinic.Repositories;
using VetClinic.Services;

namespace VetClinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var database = new Database();
            // DataSeeder.Seed(database);

            var patientRepository = new PatientRepository(database);
            var petRepository = new PetRepository(database);
            var veterinarianRepository = new VeterinarianRepository(database);
            var appointmentRepository = new AppointmentRepository(database);

            var patientService = new PatientService(patientRepository);
            var petService = new PetService(petRepository);
            var veterinarianService = new VeterinarianService(veterinarianRepository);
            var appointmentService = new AppointmentService(appointmentRepository);

            var serviceFactory = new VeterinaryServiceFactory();

            Console.WriteLine("Welcome to the Vet Clinic!");

            var pet = petService.FindPet(1);
            var veterinarian = veterinarianService.FindVeterinarian(1);

            if (pet != null && veterinarian != null)
            {
                var appointment = new Appointment
                {
                    Id = 1,
                    PetId = pet.Id,
                    VeterinarianId = veterinarian.Id,
                    Date = DateTime.Now.AddDays(1),
                    Reason = "Regular check-up"
                };

                if (appointmentService.ScheduleAppointment(appointment))
                {
                    Console.WriteLine("Appointment scheduled successfully!");
                }
                else
                {
                    Console.WriteLine("Could not schedule appointment due to a conflict.");
                }

                var consultation = serviceFactory.CreateService("general consultation");
                consultation.PerformService(pet);

                var vaccination = serviceFactory.CreateService("vaccination");
                vaccination.PerformService(pet);
            }
        }
    }
}
