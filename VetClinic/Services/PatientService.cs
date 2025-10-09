
using VetClinic.Models;
using VetClinic.Repositories;

namespace VetClinic.Services
{
    public class PatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void RegisterPatient(Patient patient)
        {
            _patientRepository.Add(patient);
        }

        public Patient FindPatient(Guid id)
        {
            return _patientRepository.GetById(id);
        }
    }
}
