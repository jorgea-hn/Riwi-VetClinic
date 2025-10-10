
using System;

namespace VetClinic.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PetId { get; set; }
        public Guid VeterinarianId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
