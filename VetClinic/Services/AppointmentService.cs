
using System;
using System.Linq;
using VetClinic.Models;
using VetClinic.Repositories;

namespace VetClinic.Services
{
    public class AppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private const int AppointmentDuration = 30; // Minutes

        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // Crear / Agendar cita
        public bool ScheduleAppointment(Appointment appointment)
        {
            var appointments = _appointmentRepository.GetAll();

            // La nueva cita no puede estar en el pasado
            if (appointment.Date < DateTime.Now)
            {
                return false;
            }

            var newAppointmentEnd = appointment.Date.AddMinutes(AppointmentDuration);

            foreach (var existingAppointment in appointments.Where(a => a.VeterinarianId == appointment.VeterinarianId))
            {
                var existingAppointmentEnd = existingAppointment.Date.AddMinutes(AppointmentDuration);

                // Comprobar si hay solapamiento
                if (appointment.Date < existingAppointmentEnd && newAppointmentEnd > existingAppointment.Date)
                {
                    return false; // Hay conflicto
                }
            }

            _appointmentRepository.Add(appointment);
            return true;
        }

        // Leer - Buscar cita por Id
        public Appointment FindAppointment(Guid id)
        {
            return _appointmentRepository.GetById(id);
        }

        // Leer - Obtener todas las citas
        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        // Actualizar cita
        public void UpdateAppointment(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }

        // Eliminar / Cancelar cita
        public void CancelAppointment(Guid id)
        {
            _appointmentRepository.Delete(id);
        }
    }
}
