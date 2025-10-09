using VetClinic.Interfaces;

namespace VetClinic.Models;

public class Pet : Animal, IRegistrable
{
    public string Breed { get; set; }
    public Patient Owner { get; set; }
    public Guid Id { get; set; }

    public Pet(string name, int age, string species, string breed, Patient owner)
        : base(name, age, species)
    {
        Breed = breed;
        Owner = owner;
    }

    public override void MakeSound()
    {
        switch (Species.ToLower())
        {
            case "dog":
                Console.WriteLine("Woof!");
                break;
            case "cat":
                Console.WriteLine("Meow!");
                break;
            default:
                Console.WriteLine("Unknown animal sound.");
                break;
        }
    }

    public void Register()
    {
        Console.WriteLine($"Registering pet: {Name}, Species: {Species}, Owner: {Owner.Name}");
    }
}