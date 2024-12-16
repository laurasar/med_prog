using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Services
{
    public class PatientServiceProxy
    {
        private static object _lock = new object();
        private static PatientServiceProxy? instance;
        public List<Patient> Patients { get; private set; }

        public static PatientServiceProxy Current
        {
            get
            {
                lock (_lock)
                {
                    instance ??= new PatientServiceProxy();
                }
                return instance;
            }
        }

        private PatientServiceProxy()
        {
            Patients = new List<Patient>
            {
                new Patient { Id = 1, Name = "John Doe", Race = "Caucasian", Gender = "Male" },
                new Patient { Id = 2, Name = "Jane Doe", Race = "Caucasian", Gender = "Female" }
            };
        }

        public int LastKey => Patients.Any() ? Patients.Max(x => x.Id) : 0;

        public void AddOrUpdatePatient(Patient patient)
        {
            if (patient.Id <= 0)
            {
                patient.Id = LastKey + 1;
                Patients.Add(patient);
            }
            else
            {
                var existingIndex = Patients.FindIndex(p => p.Id == patient.Id);
                if (existingIndex >= 0)
                {
                    Patients[existingIndex] = patient;
                }
            }
        }

        public void DeletePatient(int id)
        {
            var patient = Patients.FirstOrDefault(p => p.Id == id);
            if (patient != null)
            {
                Patients.Remove(patient);
            }
        }
    }
}
