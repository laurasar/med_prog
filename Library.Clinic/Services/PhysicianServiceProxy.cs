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
        public static List<Physician> Physicians { get; private set; } = new List<Physician>
        {
            new Physician
            {
                licenseNum = 1,
                Name = "Dr. Smith",
                Specialization = "General Practice",
                gradDate = new DateTime(2010, 5, 15)
            }
        };

        public static int LastKey => Physicians.Any() ? Physicians.Max(x => x.licenseNum) : 0;

        public static void AddPhysician(Physician physician)
        {
            if (physician.licenseNum <= 0)
            {
                physician.licenseNum = LastKey + 1;
            }
            Physicians.Add(physician);
        }

        public static void UpdatePhysician(Physician physician)
        {
            var existingIndex = Physicians.FindIndex(p => p.licenseNum == physician.licenseNum);
            if (existingIndex >= 0)
            {
                Physicians[existingIndex] = physician;
            }
        }

        public static void DeletePhysician(int license)
        {
            var physician = Physicians.FirstOrDefault(p => p.licenseNum == license);
            if (physician != null)
            {
                Physicians.Remove(physician);
            }
        }
    }
}