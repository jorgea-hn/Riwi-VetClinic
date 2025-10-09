
using System.Collections.Generic;
using VetClinic.Models;

namespace VetClinic.Data
{
    public class Database
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Pet> Pets { get; set; } = new List<Pet>();
        public List<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
