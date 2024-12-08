using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Models
{
    public class Patient
    {
        public int Id { get; set; } 

        private string? name; // example of a field which is a data member 
        public string Name
        {
            get
            {
                return name ?? string.Empty;
            }
            set
            {
                name = value;
            }
        }

        private DateTime? birthday;
        public DateTime Birthday
        {
            get
            {
                return birthday ?? DateTime.MinValue;
            }

            set
            {
                birthday = value;
            }
        }

        private string? address; 
        public string Address {
            get
            {
                return address ?? string.Empty;
            }
                
             set
            {
                address = value; 
            }
        }

        private string race; 
        public string Race
        {
            get
            {
                return race ?? string.Empty;
            }
            set
            {
                race = value; 
            }
        }

        private string gender; 
        public string Gender
        {
            get
            {
                return gender ?? string.Empty;
            }
            set
            {
                gender = value;
            }
        }

        private List<string> diagnoses = new List<string>();

        public List<string> Diagnoses
        {
            get
            {
                return diagnoses;
            }
            set
            {
                diagnoses = value;
            }

        }

        

        private List<string> prescriptions = new List<string>();
        public List<string> Prescriptions
        {
            get
            {
                return prescriptions;
            }
            set
            {
                prescriptions = value;
            }
        }

        // And adding the helper methods
        public void AddPrescription(string prescription)
        {
            prescriptions.Add(prescription);
        }

        public Patient() // default constructor 
        {
            name = string.Empty;
            Address = string.Empty;
            Birthday = DateTime.MinValue;
            Race = string.Empty;
            Gender = string.Empty;

            prescriptions = new List<string>();
            diagnoses = new List<string>();
        }


    }
}
