
namespace VetClinic.Models
{
    public class Veterinarian(string? name, string? specialization)
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
    }
}
