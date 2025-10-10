
# VetClinic

**Author:** Jorge Henriquez

This is a simple console application for managing a vet clinic. It allows you to manage patients, pets, veterinarians, and appointments.

## Features

*   **Patient Management:**
    *   List all patients.
    *   Add a new patient.
    *   Update a patient's information.
    *   Delete a patient.
*   **Pet Management:**
    *   List all pets.
    *   Add a new pet.
    *   Update a pet's information.
    *   Delete a pet.
*   **Veterinarian Management:**
    *   List all veterinarians.
    *   Add a new veterinarian.
    *   Update a veterinarian's information.
    *   Delete a veterinarian.
*   **Appointment Management:**
    *   List all appointments.
    *   Schedule a new appointment.
    *   Cancel an appointment.

## Folder Structure

```
.
├── README.md
├── VetClinic.sln
└── VetClinic
    ├── Data
    │   └── Database.cs
    ├── DataSeeder.cs
    ├── Exceptions
    │   └── MascotaNoEncontradaException.cs
    ├── Interfaces
    │   ├── INotificable.cs
    │   ├── IRegistrable.cs
    │   └── IVeterinaryService.cs
    ├── Models
    │   ├── Animal.cs
    │   ├── Appointment.cs
    │   ├── Patient.cs
    │   ├── Pet.cs
    │   └── Veterinarian.cs
    ├── Program.cs
    ├── Repositories
    │   ├── AppointmentRepository.cs
    │   ├── IRepository.cs
    │   ├── PatientRepository.cs
    │   ├── PetRepository.cs
    │   └── VeterinarianRepository.cs
    ├── Services
    │   ├── AppointmentService.cs
    │   ├── GeneralConsultation.cs
    │   ├── PatientService.cs
    │   ├── PetService.cs
    │   ├── Vaccination.cs
    │   ├── VeterinarianService.cs
    │   ├── VeterinaryService.cs
    │   └── VeterinaryServiceFactory.cs
    ├── Utils
    │   ├── Helper.cs
    │   └── Logger.cs
    └── VetClinic.csproj
```

## How to Run

1.  Clone the repository.
2.  Open the solution in Visual Studio.
3.  Build the solution.
4.  Run the application.

## Future Improvements

*   Add more detailed validation for all inputs.
*   Implement a more robust data storage solution, such as a database.
*   Add more features, such as the ability to view a pet's appointment history.
*   Create a graphical user interface (GUI).
