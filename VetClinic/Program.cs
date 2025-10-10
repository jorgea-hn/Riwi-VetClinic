
using System;
using VetClinic.Data;
using VetClinic.Models;
using VetClinic.Repositories;
using VetClinic.Services;

namespace VetClinic
{
    public class Program
    {
        static PatientService patientService;
        static PetService petService;
        static VeterinarianService veterinarianService;
        static AppointmentService appointmentService;

        public static void Main(string[] args)
        {
            var database = new Database();
            // DataSeeder.Seed(database);

            var patientRepository = new PatientRepository(database);
            var petRepository = new PetRepository(database);
            var veterinarianRepository = new VeterinarianRepository(database);
            var appointmentRepository = new AppointmentRepository(database);

            patientService = new PatientService(patientRepository);
            petService = new PetService(petRepository);
            veterinarianService = new VeterinarianService(veterinarianRepository);
            appointmentService = new AppointmentService(appointmentRepository);

            Console.WriteLine("Welcome to the Vet Clinic!");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Patients");
                Console.WriteLine("2. Pets");
                Console.WriteLine("3. Veterinarians");
                Console.WriteLine("4. Appointments");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PatientMenu();
                        break;
                    case "2":
                        PetMenu();
                        break;
                    case "3":
                        VeterinarianMenu();
                        break;
                    case "4":
                        AppointmentMenu();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using Vet Clinic!");
        }

        static void PatientMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n-- Patients Menu --");
                Console.WriteLine("1. List all patients");
                Console.WriteLine("2. Add a new patient");
                Console.WriteLine("3. Update a patient");
                Console.WriteLine("4. Delete a patient");
                Console.WriteLine("0. Back");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var patients = patientService.GetAllPatients();
                        foreach (var p in patients)
                            Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}, Phone: {p.Phone}");
                        break;

                    case "2":
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Address: ");
                        var address = Console.ReadLine();
                        Console.Write("Phone: ");
                        var phone = Console.ReadLine();

                        var newPatient = new Patient(name, age, address, phone);
                        patientService.AddPatient(newPatient);
                        Console.WriteLine("Patient added.");
                        break;

                    case "3":
                        Console.Write("Enter patient Id to update: ");
                        var idStr = Console.ReadLine();
                        if (Guid.TryParse(idStr, out Guid idToUpdate))
                        {
                            var patient = patientService.FindPatient(idToUpdate);
                            if (patient != null)
                            {
                                Console.Write("New Name: ");
                                patient.Name = Console.ReadLine();

                                Console.Write("New Age: ");
                                patient.Age = int.Parse(Console.ReadLine() ?? "0");

                                Console.Write("New Address: ");
                                patient.Address = Console.ReadLine();

                                Console.Write("New Phone: ");
                                patient.Phone = Console.ReadLine();

                                patientService.UpdatePatient(patient);
                                Console.WriteLine("Patient updated.");
                            }
                            else
                            {
                                Console.WriteLine("Patient not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id format.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter patient Id to delete: ");
                        var idDelStr = Console.ReadLine();
                        if (Guid.TryParse(idDelStr, out Guid idToDelete))
                        {
                            patientService.DeletePatient(idToDelete);
                            Console.WriteLine("Patient deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id format.");
                        }
                        break;

                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void PetMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n-- Pets Menu --");
                Console.WriteLine("1. List all pets");
                Console.WriteLine("2. Add a new pet");
                Console.WriteLine("3. Update a pet");
                Console.WriteLine("4. Delete a pet");
                Console.WriteLine("0. Back");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var pets = petService.GetAllPets();
                        foreach (var pet in pets)
                            Console.WriteLine($"Id: {pet.Id}, Name: {pet.Name}, Species: {pet.Species}, Owner: {pet.Owner.Name}");
                        break;

                    case "2":
                        Console.Write("Name: ");
                        var petName = Console.ReadLine();
                        Console.Write("Age: ");
                        int petAge = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Species: ");
                        var species = Console.ReadLine();
                        Console.Write("Breed: ");
                        var breed = Console.ReadLine();

                        Console.Write("Owner Id: ");
                        var ownerIdStr = Console.ReadLine();
                        if (Guid.TryParse(ownerIdStr, out Guid ownerId))
                        {
                            var owner = patientService.FindPatient(ownerId);
                            if (owner != null)
                            {
                                var newPet = new Pet(petName, petAge, species, breed, owner);
                                petService.AddPet(newPet);
                                owner.AddPet(newPet);
                                Console.WriteLine("Pet added.");
                            }
                            else
                            {
                                Console.WriteLine("Owner not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Owner Id.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter pet Id to update: ");
                        var petIdStr = Console.ReadLine();
                        if (Guid.TryParse(petIdStr, out Guid petId))
                        {
                            var pet = petService.FindPet(petId);
                            if (pet != null)
                            {
                                Console.Write("New Name: ");
                                pet.Name = Console.ReadLine();

                                Console.Write("New Age: ");
                                pet.Age = int.Parse(Console.ReadLine() ?? "0");

                                Console.Write("New Species: ");
                                pet.Species = Console.ReadLine();

                                Console.Write("New Breed: ");
                                pet.Breed = Console.ReadLine();

                                petService.UpdatePet(pet);
                                Console.WriteLine("Pet updated.");
                            }
                            else
                            {
                                Console.WriteLine("Pet not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id format.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter pet Id to delete: ");
                        var petDelStr = Console.ReadLine();
                        if (Guid.TryParse(petDelStr, out Guid petToDelete))
                        {
                            petService.DeletePet(petToDelete);
                            Console.WriteLine("Pet deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id format.");
                        }
                        break;

                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void VeterinarianMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n-- Veterinarians Menu --");
                Console.WriteLine("1. List all veterinarians");
                Console.WriteLine("2. Add a new veterinarian");
                Console.WriteLine("3. Update a veterinarian");
                Console.WriteLine("4. Delete a veterinarian");
                Console.WriteLine("0. Back");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var vets = veterinarianService.GetAllVeterinarians();
                        foreach (var vet in vets)
                            Console.WriteLine($"Id: {vet.Id}, Name: {vet.Name}, Specialization: {vet.Specialization}");
                        break;

                    case "2":
                        Console.Write("Name: ");
                        var name = Console.ReadLine();
                        Console.Write("Specialization: ");
                        var specialization = Console.ReadLine();

                        var newVet = new Veterinarian(name, specialization);
                        veterinarianService.AddVeterinarian(newVet);
                        Console.WriteLine("Veterinarian added.");
                        break;

                    case "3":
                        Console.Write("Enter veterinarian Id to update: ");
                        var idStr = Console.ReadLine();
                        if (Guid.TryParse(idStr, out Guid id))
                        {
                            var vet = veterinarianService.FindVeterinarian(id);
                            if (vet != null)
                            {
                                Console.Write("New Name: ");
                                vet.Name = Console.ReadLine();

                                Console.Write("New Specialization: ");
                                vet.Specialization = Console.ReadLine();

                                veterinarianService.UpdateVeterinarian(vet);
                                Console.WriteLine("Veterinarian updated.");
                            }
                            else
                            {
                                Console.WriteLine("Veterinarian not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id format.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter veterinarian Id to delete: ");
                        var idDelStr = Console.ReadLine();
                        if (Guid.TryParse(idDelStr, out Guid idToDelete))
                        {
                            veterinarianService.DeleteVeterinarian(idToDelete);
                            Console.WriteLine("Veterinarian deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id format.");
                        }
                        break;

                    case "0":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void AppointmentMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n-- Appointments Menu --");
                Console.WriteLine("1. List all appointments");
                Console.WriteLine("2. Schedule a new appointment");
                Console.WriteLine("3. Cancel an appointment");
                Console.WriteLine("0. Back");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var appointments = appointmentService.GetAllAppointments();
                        foreach (var appt in appointments)
                        {
                            Console.WriteLine($"Id: {appt.Id}, PetId: {appt.PetId}, VetId: {appt.VeterinarianId}, Date: {appt.Date}, Reason: {appt.Reason}");
                        }
                        break;

                    case "2":
                        Console.Write("Pet Id: ");
                        var petIdStr = Console.ReadLine();
                        Console.Write("Veterinarian Id: ");
                        var vetIdStr = Console.ReadLine();
                        Console.Write("Date (yyyy-MM-dd HH:mm): ");
                        var dateStr = Console.ReadLine();
                        Console.Write("Reason: ");
                        var reason = Console.ReadLine();

                        if (Guid.TryParse(petIdStr, out Guid petId) &&
                            Guid.TryParse(vetIdStr, out Guid vetId) &&
                            DateTime.TryParse(dateStr, out DateTime date))
                        {
                            var appointment = new Appointment
                            {
                                Id = Guid.NewGuid(),
                                PetId = petId,
                                VeterinarianId = vetId,
                                Date = date,
                                Reason = reason
                            };

                            if (appointmentService.ScheduleAppointment(appointment))
                                Console.WriteLine("Appointment scheduled.");
                            else
                                Console.WriteLine("Could not schedule appointment due to a conflict.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input(s). Please check the IDs and date format.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter appointment Id to cancel: ");
                        var apptIdStr = Console.ReadLine();
                        if (Guid.TryParse(apptIdStr, out Guid apptId))
                        {
                            appointmentService.CancelAppointment(apptId);
                            Console.WriteLine("Appointment canceled.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id format.");
                        }
                        break;

                    case "0":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
