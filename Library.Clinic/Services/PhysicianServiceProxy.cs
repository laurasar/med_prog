using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.Clinic.Services
{


    public static class PhysicianServiceProxy
    {
        public static int LastKey
        {
            get
            {
                if (Physicians.Any())
                {
                    return Physicians.Select(x => x.licenseNum).Max();
                }
                else
                {
                    return 0;
                }
            }
        }
        public static List<Physician> Physicians { get; private set; } = new List<Physician>();  // Make consistent naming

        public static void AddPhysician(Physician physician)
        {
            if (physician.licenseNum <= 0)
            {
                physician.licenseNum = LastKey + 1;
            }
            Physicians.Add(physician);  // Use correct property name
        }

        public static void DeletePhysician(int license)
        {
            var physicianToRemove = Physicians.FirstOrDefault(p => p.licenseNum == license);
            if (physicianToRemove != null)
            {
                Physicians.Remove(physicianToRemove);
            }
        }
    }
} 
