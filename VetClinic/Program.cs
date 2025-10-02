// See https://aka.ms/new-console-template for more information

using VetClinic.Models;
using VetClinic.Services;

List<Patient> patients = new List<Patient>();
bool exit = false;

while (!exit)
{
    Console.WriteLine("\n--- Health Clinic Menu ---");
    Console.WriteLine("1. Register patient");
    Console.WriteLine("2. List patients");
    Console.WriteLine("3. Search patient");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");

    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            PatientService.RegisterPatient(patients);
            break;
        case "2":
            PatientService.ListPatients(patients);
            break;
        case "3":
            Console.Write("Enter the patient name to search: ");
            string? name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                PatientService.SearchPatientByName(patients, name);
            }
            else
            {
                Console.WriteLine("Invalid name.");
            }
            break;
        case "4":
            exit = true;
            Console.WriteLine("Exiting program...");
            break;
        default:
            Console.WriteLine("Invalid option. Please choose 1, 2, 3, or 4.");
            break;
    }
}
