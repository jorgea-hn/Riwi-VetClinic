
using VetClinic.Models;
using VetClinic.Repositories;

namespace VetClinic.Services
{
    public class PetService
    {
        private readonly IRepository<Pet> _petRepository;

        public PetService(IRepository<Pet> petRepository)
        {
            _petRepository = petRepository;
        }

        public void RegisterPet(Pet pet)
        {
            _petRepository.Add(pet);
        }

        public Pet FindPet(int id)
        {
            return _petRepository.GetById(id);
        }
    }
}
