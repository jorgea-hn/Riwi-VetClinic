using VetClinic.Interfaces;

namespace VetClinic.Models;

public class Patient : IRegistrable, INotificable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }

    private string _phone;
    public string Phone
    {
        get => _phone;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone cannot be empty.");
            _phone = value;
        }
    }

    public int Age { get; set; }
    public string Address { get; set; }
    public List<Pet> Pets { get; set; } = new();

    public Patient(string name, int age, string address, string phone)
    {
        Name = name;
        Age = age;
        Address = address;
        Phone = phone;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Patient Id: {Id}, Name: {Name}, Age: {Age}, Phone: {Phone}, Address: {Address}");
    }

    public void Register()
    {
        Console.WriteLine($"Registering patient: {Name} with ID: {Id}");
    }

    public void AddPet(Pet pet)
    {
        Pets.Add(pet);
    }
    
    public void EnviarNotificacion(string mensaje)
    {
        Console.WriteLine($"[NOTIFICACIÓN] Para {Name}: {mensaje}");
    }
}