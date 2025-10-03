namespace VetClinic.Services;

public class Vaccination : VeterinaryService
{
    public override void Attend()
    {
        Console.WriteLine("Performing vaccination...");
    }
}