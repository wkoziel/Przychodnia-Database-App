using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;
using System.Collections.Generic;

namespace Przychodnia
{
    class Lists
    {
        public static List<Appointment> Appointments { get => AppointmentRepo.GetAllAppoitments(); }
        public static List<Clinic> Clinics { get => ClinicRepo.GetAllClinics(); }
        public static List<DocAssignment> DocAssignments { get => DocAssignmentRepo.GetAllDocAssignments(); }
        public static List<Doctor> Doctors { get => DoctorRepo.GetAllDoctors(); }
        public static List<Patient> Patients { get => PatientRepo.GetAllPatients(); }
        public static List<Room> Rooms { get => RoomRepo.GetAllRooms(); }
        public static List<Users> Users { get => UsersRepo.GetAllUsers(); }
    }
}
