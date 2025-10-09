
using System;
using System.Linq;
using VetClinic.Models;
using VetClinic.Repositories;

namespace VetClinic.Services
{
    public class AppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            var appointments = _appointmentRepository.GetAll();
            if (appointments.Any(a => a.VeterinarianId == appointment.VeterinarianId && a.Date == appointment.Date))
            {
                return false; // Overlapping appointment
            }
            _appointmentRepository.Add(appointment);
            return true;
        }

        public Appointment FindAppointment(int id)
        {
            return _appointmentRepository.GetById(id);
        }
    }
}
