using VetClinic.Models;

namespace VetClinic.Services;

public class PatientService
{
    public static void RegisterPatient(List<Patient> patients)
    {
        try
        {
            Console.WriteLine("Register a new patient:");

            Console.Write("Name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) return;

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid input"));

            Console.Write("Address: ");
            string? address = Console.ReadLine();

            Console.Write("Phone: ");
            string? phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone)) return;

            var patient = new Patient(name, age, address ?? "", phone);
            patients.Add(patient);
            Console.WriteLine("Patient registered successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void ListPatients(List<Patient> patients)
    {
        if (!patients.Any())
        {
            Console.WriteLine("No patients registered.");
            return;
        }

        foreach (var patient in patients)
        {
            patient.ShowInfo();
            if (patient.Pets.Any())
            {
                Console.WriteLine("Pets:");
                foreach (var pet in patient.Pets)
                {
                    Console.WriteLine($" - {pet.Name} ({pet.Species}, Breed: {pet.Breed})");
                }
            }
            else
            {
                Console.WriteLine("No pets registered for this patient.");
            }
            Console.WriteLine();
        }
    }
}
        
