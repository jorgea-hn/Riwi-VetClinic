
using VetClinic.Data;
using VetClinic.Models;

namespace VetClinic
{
    public static class DataSeeder
    {
        public static void Seed(Database database)
        {
            var patient1 = new Patient("John Doe", 30, "123 Main St", "123-456-7890");
            database.Patients.Add(patient1);

            var patient2 = new Patient("Jane Smith", 25, "456 Oak Ave", "098-765-4321");
            database.Patients.Add(patient2);

            var pet1 = new Pet("Buddy", 5, "Dog", "Golden Retriever", patient1);
            database.Pets.Add(pet1);
            patient1.AddPet(pet1);

            var pet2 = new Pet("Lucy", 3, "Cat", "Siamese", patient2);
            database.Pets.Add(pet2);
            patient2.AddPet(pet2);

            var pet3 = new Pet("Max", 8, "Dog", "German Shepherd", patient1);
            database.Pets.Add(pet3);
            patient1.AddPet(pet3);

            var veterinarian1 = new Veterinarian("Dr. Smith", "General Practice");
            database.Veterinarians.Add(veterinarian1);

            var veterinarian2 = new Veterinarian("Dr. Jones", "Surgery");
            database.Veterinarians.Add(veterinarian2);
        }
    }
}
