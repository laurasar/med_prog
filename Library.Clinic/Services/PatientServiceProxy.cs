using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Clinic.Models; 

namespace Library.Clinic.Services
{
    // directs signals, from pt A to pt B 
    // the patient service lives on the server, not on the clients
    //machine, the proxy will tell the service what to do . 
    public static class PatientServiceProxy
    {
        public static int LastKey
        {
            get
            {
                if (Patients.Any())
                {
                    return Patients.Select(x => x.Id).Max();
                }
                else
                {
                    return 0;
                }
            }
        }
        public static List<Patient> Patients { get; private set; } = new List<Patient>();

        //public PatientServiceProxy() {
        //    patients = new List<Patient>();
        //}
        public static void AddPatient(Patient patient)
        {
            if(patient.Id <= 0)
            {
                patient.Id = LastKey +1;
            }
            Patients.Add(patient);
        }

        public static void DeletePatient(int id)
        {
            var patientToRemove = Patients.FirstOrDefault(p => p.Id == id);
            if (patientToRemove != null)
            {
                Patients.Remove(patientToRemove);
            }

        }

        public static void AddDiagnosis(int id, string diagnoses)
        {
            var x = Patients.FirstOrDefault(p => p.Id <= id);
            if (x != null)
            {
                x.Diagnoses.Add(diagnoses);
            }
        }

        public static void AddPrescription(int id, string prescription)
        {
            var x = Patients.FirstOrDefault(p => p.Id <= id);
            if (x != null)
            {
                x.Prescriptions.Add(prescription);
            }
        }

    }

    
}
