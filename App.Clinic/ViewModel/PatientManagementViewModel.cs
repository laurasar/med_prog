using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Clinic.ViewModel
{
    public class PatientManagementViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //public List<Patient> Patients
        //{
        //    get
        //    {
        //        return PatientServiceProxy.Current.Patients;
        //    }
        //}

        public ObservableCollection<Patient> Patients
        {
            get
            {
                return new ObservableCollection<Patient>(PatientServiceProxy.Current.Patients);
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged("Patients");
        }

    }
}
