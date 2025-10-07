namespace VetClinic.Exceptions;

public class MascotaNoEncontradaException: Exception
{
    public MascotaNoEncontradaException(string message) : base(message) { }
}