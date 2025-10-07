namespace VetClinic.Interfaces;
// Interfaz: se usa para definir un comportamiento que puede ser compartido por diferentes tipos
// Usamos IRegistrable para permitir que tanto Paciente como Mascota se registren en el sistema.
public interface IRegistrable
{
    void Register();
}