using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        private DateTime? appointmentTime;
        public DateTime AppointmentTime
        {
            get
            {
                return appointmentTime ?? DateTime.MinValue;
            }
            set
            {
                appointmentTime = value;
            }
        }

        private int physicianLicense;
        public int PhysicianLicense
        {
            get
            {
                return physicianLicense;
            }
            set
            {
                physicianLicense = value;
            }
        }

        private int patientId;
        public int PatientId
        {
            get
            {
                return patientId;
            }
            set
            {
                patientId = value;
            }
        }

        public Appointment()
        {
            appointmentTime = DateTime.MinValue;
            physicianLicense = 0;
            patientId = 0;
        }
    }
}

