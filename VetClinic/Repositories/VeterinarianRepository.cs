
using System.Collections.Generic;
using System.Linq;
using VetClinic.Data;
using VetClinic.Models;

namespace VetClinic.Repositories
{
    public class VeterinarianRepository : IRepository<Veterinarian>
    {
        private readonly Database _database;

        public VeterinarianRepository(Database database)
        {
            _database = database;
        }

        public void Add(Veterinarian entity)
        {
            _database.Veterinarians.Add(entity);
        }

        public void Delete(int id)
        {
            var veterinarian = GetById(id);
            if (veterinarian != null)
            {
                _database.Veterinarians.Remove(veterinarian);
            }
        }

        public IEnumerable<Veterinarian> GetAll()
        {
            return _database.Veterinarians;
        }

        public Veterinarian GetById(int id)
        {
            return _database.Veterinarians.FirstOrDefault(v => v.Id == id);
        }

        public void Update(Veterinarian entity)
        {
            var veterinarian = GetById(entity.Id);
            if (veterinarian != null)
            {
                veterinarian.Name = entity.Name;
                veterinarian.Specialization = entity.Specialization;
            }
        }
    }
}
