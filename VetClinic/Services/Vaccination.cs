
using VetClinic.Models;
using System;

namespace VetClinic.Services
{
    public class Vaccination : VeterinaryService
    {
        public override void PerformService(Pet pet)
        {
            Console.WriteLine($"Vaccinating {pet.Name}");
            // Add logic for vaccination
        }
    }
}
