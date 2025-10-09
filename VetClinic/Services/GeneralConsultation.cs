
using VetClinic.Models;
using System;

namespace VetClinic.Services
{
    public class GeneralConsultation : VeterinaryService
    {
        public override void PerformService(Pet pet)
        {
            Console.WriteLine($"Performing general consultation for {pet.Name}");
            // Add logic for general consultation
        }
    }
}
