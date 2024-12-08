// AppointmentServiceProxy.cs
using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Clinic.Services
{
    public static class AppointmentServiceProxy
    {
        public static int LastKey
        {
            get
            {
                if (Appointments.Any())
                {
                    return Appointments.Select(x => x.Id).Max();
                }
                else
                {
                    return 0;
                }
            }
        }
        public static List<Appointment> Appointments { get; private set; } = new List<Appointment>();

        public static bool IsValidAppointmentTime(DateTime appointmentTime)
        {
            // Check if it's a weekday
            if (appointmentTime.DayOfWeek == DayOfWeek.Saturday || appointmentTime.DayOfWeek == DayOfWeek.Sunday)
                return false;

            // Check if it's between 8 AM and 5 PM
            if (appointmentTime.Hour < 8 || appointmentTime.Hour >= 17)
                return false;

            return true;
        }

        public static bool IsPhysicianAvailable(int licenseNum, DateTime appointmentTime)
        {
            return !Appointments.Any(a =>
                a.PhysicianLicense == licenseNum &&
                a.AppointmentTime == appointmentTime);
        }

        public static void AddAppointment(Appointment appointment)
        {
            if (appointment.Id <= 0)
            {
                appointment.Id = LastKey + 1;
            }

            if (!IsValidAppointmentTime(appointment.AppointmentTime))
            {
                throw new ArgumentException("Appointment must be between 8 AM and 5 PM on weekdays.");
            }

            if (!IsPhysicianAvailable(appointment.PhysicianLicense, appointment.AppointmentTime))
            {
                throw new ArgumentException("Physician is already booked at this time.");
            }

            Appointments.Add(appointment);
        }

        public static void DeleteAppointment(int id)
        {
            var appointmentToRemove = Appointments.FirstOrDefault(p => p.Id == id);
            if (appointmentToRemove != null)
            {
                Appointments.Remove(appointmentToRemove);
            }
        }
    }
    
}
