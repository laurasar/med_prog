using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Models
{
    public class Patient
    {
        public int Id { get; set; }
        private string? name;
        public string Name
        {
            get => name ?? string.Empty;
            set => name = value;
        }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string SSN { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public List<MedicalNote> MedicalNotes { get; set; }

        public string Display => $"[{Id}] {Name}";

        public override string ToString() => Display;

        public Patient()
        {
            Name = string.Empty;
            Address = string.Empty;
            Birthday = DateTime.MinValue;
            SSN = string.Empty;
            Race = string.Empty;
            Gender = string.Empty;
            MedicalNotes = new List<MedicalNote>();
        }
    }
}