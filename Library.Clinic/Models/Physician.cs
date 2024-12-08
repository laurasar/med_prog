using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Models
{
    public class Physician
    {
        private string? name;
         public string Name {
            get
            {
                return name ?? string.Empty;
            }
            set
            {
                name = value;
            }
        }

        private int licensenum;
         public int licenseNum {
            get
            {
                return licensenum ;
            }
            set
            {
                licensenum = value;
            }
        }

        private DateTime? graduation;
        public DateTime gradDate {
            get
            {
                return graduation ?? DateTime.MinValue;
            }

            set
            {
                graduation = value;
            }
        }

        private string? specialization; 
        public string Specialization {
            get
            {
                return specialization ?? string.Empty;
            }
            set
            {
                specialization = value;
            }
        }

        public Physician()
        {
            name = string.Empty;
            licenseNum = int.MinValue;
            gradDate = DateTime.MinValue;
            Specialization = string.Empty;
            

        }

    }

    


}
