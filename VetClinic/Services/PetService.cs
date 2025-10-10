
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

        // Crear / Agregar mascota
        public void AddPet(Pet pet)
        {
            _petRepository.Add(pet);
        }

        // Leer - Buscar mascota por Id
        public Pet FindPet(Guid id)
        {
            return _petRepository.GetById(id);
        }

        // Leer - Obtener todas las mascotas
        public IEnumerable<Pet> GetAllPets()
        {
            return _petRepository.GetAll();
        }

        // Actualizar mascota
        public void UpdatePet(Pet pet)
        {
            _petRepository.Update(pet);
        }

        // Eliminar mascota
        public void DeletePet(Guid id)
        {
            _petRepository.Delete(id);
        }
    }
}
