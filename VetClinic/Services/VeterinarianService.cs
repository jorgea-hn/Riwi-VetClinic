
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

        public void RegisterVeterinarian(Veterinarian veterinarian)
        {
            _veterinarianRepository.Add(veterinarian);
        }

        public Veterinarian FindVeterinarian(Guid id)
        {
            return _veterinarianRepository.GetById(id);
        }
    }
}
