
using VetClinic.Data;
using VetClinic.Models;

namespace VetClinic
{
    public static class DataSeeder
    {
        public static void Seed(Database database)
        {
            var patient1 = new Patient { Id = 1, Name = "John Doe", Phone = "123-456-7890", Address = "123 Main St" };
            database.Patients.Add(patient1);

            var pet1 = new Pet { Id = 1, Name = "Buddy", Age = 5, Breed = "Golden Retriever", PatientId = 1 };
            database.Pets.Add(pet1);

            var veterinarian1 = new Veterinarian { Id = 1, Name = "Dr. Smith", Specialization = "General Practice" };
            database.Veterinarians.Add(veterinarian1);
        }
    }
}
