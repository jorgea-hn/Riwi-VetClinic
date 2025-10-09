
using System.Collections.Generic;
using System.Linq;
using VetClinic.Data;
using VetClinic.Models;

namespace VetClinic.Repositories
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly Database _database;

        public AppointmentRepository(Database database)
        {
            _database = database;
        }

        public void Add(Appointment entity)
        {
            _database.Appointments.Add(entity);
        }

        public void Delete(int id)
        {
            var appointment = GetById(id);
            if (appointment != null)
            {
                _database.Appointments.Remove(appointment);
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _database.Appointments;
        }

        public Appointment GetById(int id)
        {
            return _database.Appointments.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Appointment entity)
        {
            var appointment = GetById(entity.Id);
            if (appointment != null)
            {
                appointment.PetId = entity.PetId;
                appointment.VeterinarianId = entity.VeterinarianId;
                appointment.Date = entity.Date;
                appointment.Reason = entity.Reason;
            }
        }
    }
}
