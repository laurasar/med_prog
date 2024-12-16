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
        public string Name
        {
            get => name ?? string.Empty;
            set => name = value;
        }

        private int licensenum;
        public int licenseNum
        {
            get => licensenum;
            set => licensenum = value;
        }

        private DateTime? graduation;
        public DateTime gradDate
        {
            get => graduation ?? DateTime.MinValue;
            set => graduation = value;
        }

        private string? specialization;
        public string Specialization
        {
            get => specialization ?? string.Empty;
            set => specialization = value;
        }

        public string Display => $"[{licenseNum}] {Name} - {Specialization}";

        public Physician()
        {
            Name = string.Empty;
            licenseNum = 0;
            gradDate = DateTime.MinValue;
            Specialization = string.Empty;
        }
    }
}
