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

            Console.Write("Owner Name: ");
            string? name = Console.ReadLine();

            Console.Write("Owner Age: ");
            int age = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid input"));

            Console.Write("Phone: ");
            string? phone = Console.ReadLine();

            Console.Write("Pet Name: ");
            string? petName = Console.ReadLine();

            Console.Write("Species: ");
            string? species = Console.ReadLine();

            Console.Write("Breed: ");
            string? breed = Console.ReadLine();

            Console.Write("Symptom: ");
            string? symptom = Console.ReadLine();

            Patient newPatient = new Patient
            {
                Id = id,
                Name = name ?? "",
                Age = age,
                Phone = phone ?? "",
                PetName = petName ?? "",
                Species = species ?? "",
                Breed = breed ?? "",
                Symptom = symptom ?? ""
            };

            patients.Add(newPatient);
            Console.WriteLine("Patient registered successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

        public static void ListPatients(List<Patient> patients)
    {
        Console.WriteLine("Listing all patients:");

        if (!patients.Any())
        {
            Console.WriteLine("No patients registered.");
            return;
        }

        foreach (var p in patients)
        {
            Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Age: {p.Age}, Phone: {p.Phone}, Pet: {p.PetName}, Species: {p.Species}, Breed: {p.Breed}, Symptom: {p.Symptom}");
        }
    }

    public static void SearchPatientByName(List<Patient> patients, string name)
    {
        var found = patients.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (found != null)
        {
            Console.WriteLine($"Found: Id: {found.Id}, Name: {found.Name}, Pet: {found.PetName}, Symptom: {found.Symptom}");
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }

    public static void DictionaryDemo(List<Patient> patients)
    {
        var dict = patients.ToDictionary(p => p.Id, p => p);

        Console.WriteLine("Patient Dictionary (by ID):");
        foreach (var pair in dict)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value.Name} ({pair.Value.PetName})");
        }
    }

    public static void RunLinqQueries(List<Patient> patients)
    {
        if (!patients.Any())
        {
            Console.WriteLine("No patients for LINQ queries.");
            return;
        }

        Console.WriteLine("\n--- LINQ Menu ---");
        Console.WriteLine("1. Patients older than 30");
        Console.WriteLine("2. Select patient names");
        Console.WriteLine("3. Order by name");
        Console.WriteLine("4. Order by species descending");
        Console.WriteLine("5. Group by species");
        Console.WriteLine("6. First pet with symptom 'Fever'");
        Console.WriteLine("7. Count patients per species");
        Console.WriteLine("8. Any pet without breed?");
        Console.WriteLine("9. All pets have symptoms?");
        Console.WriteLine("10. Names in uppercase (A-Z)");
        Console.WriteLine("11. Species == 'Dog' and order by age");
        Console.WriteLine("12. Exit");
        Console.Write("Choose an option: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var over30 = patients.Where(p => p.Age > 30);
                foreach (var p in over30) Console.WriteLine($"{p.Name} - {p.Age}");
                break;

            case "2":
                var names = from p in patients select p.Name;
                foreach (var n in names) Console.WriteLine(n);
                break;

            case "3":
                var ordered = patients.OrderBy(p => p.Name);
                foreach (var p in ordered) Console.WriteLine(p.Name);
                break;

            case "4":
                var desc = patients.OrderByDescending(p => p.Species);
                foreach (var p in desc) Console.WriteLine($"{p.Name} - {p.Species}");
                break;

            case "5":
                var grouped = patients.GroupBy(p => p.Species);
                foreach (var group in grouped)
                {
                    Console.WriteLine($"Species: {group.Key}");
                    foreach (var p in group) Console.WriteLine($"- {p.PetName}");
                }
                break;

            case "6":
                var fever = patients.FirstOrDefault(p => p.Symptom.Contains("Fever", StringComparison.OrdinalIgnoreCase));
                Console.WriteLine(fever != null ? $"{fever.PetName} has Fever" : "No pet with Fever.");
                break;

            case "7":
                var count = patients.GroupBy(p => p.Species)
                                    .Select(g => new { Species = g.Key, Count = g.Count() });
                foreach (var item in count) Console.WriteLine($"{item.Species}: {item.Count}");
                break;

            case "8":
                var anyNoBreed = patients.Any(p => string.IsNullOrWhiteSpace(p.Breed));
                Console.WriteLine(anyNoBreed ? "There is a pet without breed." : "All pets have breed.");
                break;

            case "9":
                var allHaveSymptoms = patients.All(p => !string.IsNullOrWhiteSpace(p.Symptom));
                Console.WriteLine(allHaveSymptoms ? "All have symptoms." : "Some don't have symptoms.");
                break;

            case "10":
                var upper = patients.Select(p => p.Name.ToUpper()).OrderBy(n => n);
                foreach (var n in upper) Console.WriteLine(n);
                break;

            case "11":
                var dogs = patients.Where(p => p.Species.Equals("Dog", StringComparison.OrdinalIgnoreCase))
                                   .OrderBy(p => p.Age)
                                   .Select(p => new { p.Name, p.Phone });
                foreach (var d in dogs) Console.WriteLine($"{d.Name} - {d.Phone}");
                break;

            case "12":
                return;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
        
}