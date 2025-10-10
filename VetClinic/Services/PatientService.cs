
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

        // Crear / Agregar paciente
        public void AddPatient(Patient patient)
        {
            _patientRepository.Add(patient);
        }

        // Leer - Buscar paciente por Id
        public Patient FindPatient(Guid id)
        {
            return _patientRepository.GetById(id);
        }

        // Leer - Obtener todos los pacientes
        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        // Actualizar paciente
        public void UpdatePatient(Patient patient)
        {
            _patientRepository.Update(patient);
        }

        // Eliminar paciente
        public void DeletePatient(Guid id)
        {
            _patientRepository.Delete(id);
        }
    }
}
