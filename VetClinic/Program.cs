// See https://aka.ms/new-console-template for more information

using VetClinic.Models;
using VetClinic.Services;


List<Patient> patients = new List<Patient>();
bool exit = false;

while (!exit)
{
    Console.WriteLine("\n--- Vet Clinic Menu ---");
    Console.WriteLine("1. Register patient");
    Console.WriteLine("2. Register pet");
    Console.WriteLine("3. List patients and pets");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");

    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            PatientService.RegisterPatient(patients);
            break;
        case "2":
            PetService.RegisterPet(patients);
            break;
        case "3":
            PatientService.ListPatients(patients);
            break;
        case "4":
            exit = true;
            Console.WriteLine("Exiting program...");
            break;
        default:
            Console.WriteLine("Invalid option. Please choose 1-4.");
            break;
    }
}

