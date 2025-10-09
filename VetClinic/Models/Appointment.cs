
using System;

namespace VetClinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VeterinarianId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
