
using VetClinic.Models;
using VetClinic.Repositories;

namespace VetClinic.Services
{
    public class VeterinarianService
    {
        private readonly IRepository<Veterinarian> _veterinarianRepository;

        public VeterinarianService(IRepository<Veterinarian> veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        
        // Crear / Agregar veterinario
        public void AddVeterinarian(Veterinarian veterinarian)
        {
            _veterinarianRepository.Add(veterinarian);
        }

        // Leer - Buscar veterinario por Id
        public Veterinarian FindVeterinarian(Guid id)
        {
            return _veterinarianRepository.GetById(id);
        }

        // Leer - Obtener todos los veterinarios
        public IEnumerable<Veterinarian> GetAllVeterinarians()
        {
            return _veterinarianRepository.GetAll();
        }

        // Actualizar veterinario
        public void UpdateVeterinarian(Veterinarian veterinarian)
        {
            _veterinarianRepository.Update(veterinarian);
        }

        // Eliminar veterinario
        public void DeleteVeterinarian(Guid id)
        {
            _veterinarianRepository.Delete(id);
        }
    }
}
