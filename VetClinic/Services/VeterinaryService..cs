using VetClinic.Interfaces;

namespace VetClinic.Services;

public abstract class VeterinaryService : IVeterinaryService
{
    public abstract void Attend();
}