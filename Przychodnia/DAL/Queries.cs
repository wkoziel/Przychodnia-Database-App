using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;
using System.Collections.Generic;

namespace Przychodnia.DAL
{
    class Queries
    {
        public List<Appointment> Appointments { get => AppointmentRepo.GetAllAppoitments(); }
        public List<Clinic> Clinics { get => ClinicRepo.GetAllClinics(); }
        public List<DocAssignment> DocAssignments { get => DocAssignmentRepo.GetAllDocAssignments(); }
        public List<Doctor> Doctors { get => DoctorRepo.GetAllDoctors(); }
        public List<Patient> Patients { get => PatientRepo.GetAllPatients(); }
        public List<Room> Rooms { get => RoomRepo.GetAllRooms(); }
    }
}
