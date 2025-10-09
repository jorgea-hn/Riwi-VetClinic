
using System.Collections.Generic;
using System.Linq;
using VetClinic.Data;
using VetClinic.Models;

namespace VetClinic.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly Database _database;
        private IRepository<Patient> _repositoryImplementation;

        public PatientRepository(Database database)
        {
            _database = database;
        }

        public void Add(Patient entity)
        {
            _database.Patients.Add(entity);
        }

        public void Delete(Guid id)
        {
            var patient = GetById(id);
            if (patient != null)
            {
                _database.Patients.Remove(patient);
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            return _database.Patients;
        }

        public Patient GetById(Guid id)
        {
            return _database.Patients.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Patient entity)
        {
            var patient = GetById(entity.Id);
            if (patient != null)
            {
                patient.Name = entity.Name;
                patient.Phone = entity.Phone;
                patient.Address = entity.Address;
            }
        }
    }
}
