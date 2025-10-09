
using System.Collections.Generic;
using System.Linq;
using VetClinic.Data;
using VetClinic.Models;

namespace VetClinic.Repositories
{
    public class PetRepository : IRepository<Pet>
    {
        private readonly Database _database;

        public PetRepository(Database database)
        {
            _database = database;
        }

        public void Add(Pet entity)
        {
            _database.Pets.Add(entity);
        }

        public void Delete(int id)
        {
            var pet = GetById(id);
            if (pet != null)
            {
                _database.Pets.Remove(pet);
            }
        }

        public IEnumerable<Pet> GetAll()
        {
            return _database.Pets;
        }

        public Pet GetById(int id)
        {
            return _database.Pets.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Pet entity)
        {
            var pet = GetById(entity.Id);
            if (pet != null)
            {
                pet.Name = entity.Name;
                pet.Age = entity.Age;
                pet.Breed = entity.Breed;
                pet.PatientId = entity.PatientId;
            }
        }
    }
}
