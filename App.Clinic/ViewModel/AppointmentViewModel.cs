using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Clinic.ViewModels
{
    public class AppointmentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Appointment? Model { get; set; }

        public ObservableCollection<Patient> Patients =>
            new(PatientServiceProxy.Current.Patients);

        public ObservableCollection<Physician> Physicians =>
            new(PhysicianServiceProxy.Physicians);

        public DateTime MinStartDate => DateTime.Today;

        public DateTime StartDate
        {
            get => Model?.StartTime?.Date ?? DateTime.Today;
            set
            {
                if (Model != null)
                {
                    Model.StartTime = value;
                    RefreshTime();
                }
            }
        }

        public TimeSpan StartTime { get; set; }

        public bool IsValidAppointmentTime()
        {
            if (Model?.StartTime == null) return false;

            var startTime = Model.StartTime.Value;

            if (startTime.Hour < 8 || startTime.Hour >= 17)
                return false;

            if (startTime.DayOfWeek == DayOfWeek.Saturday ||
                startTime.DayOfWeek == DayOfWeek.Sunday)
                return false;

            var appointments = AppointmentServiceProxy.Current.Appointments;
            return !appointments.Any(a =>
                a.Id != Model.Id &&
                a.PhysicianLicense == Model.PhysicianLicense &&
                a.StartTime == Model.StartTime);
        }

        public void AddOrUpdate()
        {
            if (Model != null && IsValidAppointmentTime())
            {
                AppointmentServiceProxy.Current.AddOrUpdate(Model);
            }
            else
            {
                throw new InvalidOperationException(
                    "Invalid appointment time or physician is double-booked");
            }
        }

        public void RefreshTime()
        {
            if (Model?.StartTime != null)
            {
                Model.StartTime = StartDate.Add(StartTime);
                Model.EndTime = Model.StartTime.Value.AddHours(1);
            }
        }

        public AppointmentViewModel()
        {
            Model = new Appointment();
        }

        public AppointmentViewModel(Appointment appointment)
        {
            Model = appointment;
        }
    }
}