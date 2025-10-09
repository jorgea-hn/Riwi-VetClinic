
using System;

namespace VetClinic.Services
{
    public class VeterinaryServiceFactory
    {
        public VeterinaryService CreateService(string serviceType)
        {
            switch (serviceType.ToLower())
            {
                case "general consultation":
                    return new GeneralConsultation();
                case "vaccination":
                    return new Vaccination();
                default:
                    throw new ArgumentException("Invalid service type");
            }
        }
    }
}
