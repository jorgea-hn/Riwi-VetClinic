namespace VetClinic.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    
    public string Phone { get; set; }   
    public string Symptom { get; set; }
    
    
    public string PetName { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
}