using VetClinic.Models;
using VetClinic.Exceptions;
using VetClinic.Utils;

namespace VetClinic.Services;

public class PetService
{
    public static void RegisterPet(List<Patient> patients)
    {
        try
        {
            Console.Write("Enter patient ID: ");
            string? idInput = Console.ReadLine();
            if (!Guid.TryParse(idInput, out Guid patientId))
            {
                Console.WriteLine("Invalid GUID format.");
                return;
            }

            var owner = patients.FirstOrDefault(p => p.Id == patientId);
            if (owner == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write("Pet Name: ");
            string? petName = Console.ReadLine();
            Console.Write("Species: ");
            string? species = Console.ReadLine();
            Console.Write("Breed: ");
            string? breed = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid input"));

            if (string.IsNullOrWhiteSpace(petName) || string.IsNullOrWhiteSpace(species) || string.IsNullOrWhiteSpace(breed))
                throw new ArgumentException("All pet fields are required.");

            var pet = new Pet(petName, age, species, breed, owner);
            pet.Register();
            owner.AddPet(pet);
            Console.WriteLine("Pet registered successfully!");
        }
        catch (MascotaNoEncontradaException ex)
        {
            Logger.LogError(ex.Message);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message);
        }
    }
}