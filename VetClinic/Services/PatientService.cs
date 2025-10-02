using VetClinic.Models;

namespace VetClinic.Services;

public class PatientService
{
public static void RegisterPatient(List<Patient> patients)
        {
            Console.WriteLine("Register a new patient:");

            try
            {
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid input"));

                Console.Write("Name: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    return;
                }

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid input"));
                if (age < 0)
                {
                    Console.WriteLine("Age cannot be negative.");
                    return;
                }

                Console.Write("Symptom: ");
                string? symptom = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(symptom))
                {
                    Console.WriteLine("Symptom cannot be empty.");
                    return;
                }

                Patient newPatient = new Patient
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Symptom = symptom
                };

                patients.Add(newPatient);
                Console.WriteLine("Patient registered successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input format is incorrect. Please enter valid numbers for Id and Age.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void ListPatients(List<Patient> patients)
        {
            Console.WriteLine("Listing all patients:");

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients registered.");
                return;
            }

            foreach (var p in patients)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}, Symptom: {p.Symptom}");
            }
        }

        public static void SearchPatientByName(List<Patient> patients, string name)
        {
            Console.WriteLine($"Searching for patient with name '{name}'...");

            var found = patients.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                Console.WriteLine($"Patient found: Id: {found.Id}, Name: {found.Name}, Age: {found.Age}, Symptom: {found.Symptom}");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
        
}