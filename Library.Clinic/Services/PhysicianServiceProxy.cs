using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.Clinic.Services
{
    public class PhysicianServiceProxy
    {
        private static object _lock = new object();
        private static PhysicianServiceProxy? instance;

        public List<Physician> Physicians { get; private set; }

        public static PhysicianServiceProxy Current
        {
            get
            {
                lock (_lock)
                {
                    instance ??= new PhysicianServiceProxy();
                }
                return instance;
            }
        }

        private PhysicianServiceProxy()
        {
            Physicians = new List<Physician>
        {
            new Physician
            {
                licenseNum = 1,
                Name = "Dr. Smith",
                Specialization = "General Practice",
                gradDate = new DateTime(2010, 5, 15)
            }
        };
        }

        public void AddPhysician(Physician physician)
        {
            if (physician.licenseNum <= 0)
            {
                physician.licenseNum = LastKey + 1;
            }
            Physicians.Add(physician);
        }

        public void UpdatePhysician(Physician physician)
        {
            var existingIndex = Physicians.FindIndex(p => p.licenseNum == physician.licenseNum);
            if (existingIndex >= 0)
            {
                Physicians[existingIndex] = physician;
            }
        }

        public void DeletePhysician(int license)
        {
            var physician = Physicians.FirstOrDefault(p => p.licenseNum == license);
            if (physician != null)
            {
                Physicians.Remove(physician);
            }
        }

        public int LastKey
        {
            get
            {
                if (Physicians.Any())
                {
                    return Physicians.Max(x => x.licenseNum);
                }
                return 0;
            }
        }
    }
}