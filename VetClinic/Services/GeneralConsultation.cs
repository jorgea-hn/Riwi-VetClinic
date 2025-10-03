namespace VetClinic.Services;

public class GeneralConsultation : VeterinaryService
{
    public override void Attend()
    {
        Console.WriteLine("Performing general consultation...");
    }
}