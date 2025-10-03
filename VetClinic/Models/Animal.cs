namespace VetClinic.Models;

public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    protected Animal(string name, int age, string species)
    {
        Name = name;
        Age = age;
        Species = species;
    }

    public abstract void MakeSound();
}