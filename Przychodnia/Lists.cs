using Przychodnia.DAL.Encje;
using Przychodnia.DAL.Repozytoria;
using System;
using System.Collections.Generic;
using Przychodnia.AllTabs;

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
        public static List<Appointment> TodayAppointments()
        {
            List<Appointment> myappointments = new List<Appointment>();
            DateTime now = DateTime.Now;
            string day = now.Day < 10 ? "0" + now.Day.ToString() : now.Day.ToString();
            string month = now.Month < 10 ? "0" + now.Month.ToString() : now.Month.ToString();
            string date = $"{day}.{month}.{now.Year}";
            foreach (var item in Appointments)
                if (item.Data_wizyty == date)
                    myappointments.Add(item);
            return myappointments;
        }
        public static List<Appointment> PatientAppointments()
        {
            List<Appointment> myappointments = new List<Appointment>();
            foreach (var item in Appointments)
                if (item.PESEL == Patients[PatientTab.PatientIndex].PESEL)
                    myappointments.Add(item);
            return myappointments;
        }
        public static List<Appointment> DoctorAppointments()
        {
            List<Appointment> myappointments = new List<Appointment>();
            foreach (var item in Appointments)
                if (item.ID_lekarza == Doctors[DoctorTab.DoctorIndex].ID_lekarza)
                    myappointments.Add(item);
            return myappointments;
        }
    }
}
