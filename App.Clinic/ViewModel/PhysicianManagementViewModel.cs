using Library.Clinic.Models;
using Library.Clinic.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.Clinic.ViewModels
{
    public class PhysicianManagementViewModel : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PhysicianViewModel? selectedPhysician;
        public PhysicianViewModel? SelectedPhysician
        {
            get => selectedPhysician;
            set
            {
                if (selectedPhysician != value)
                {
                    selectedPhysician = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string? query;
        public string? Query
        {
            get => query;
            set
            {
                if (query != value)
                {
                    query = value;
                    NotifyPropertyChanged();
                    LoadPhysicians();
                }
            }
        }

        private ObservableCollection<PhysicianViewModel> physicians;
        public ObservableCollection<PhysicianViewModel> Physicians
        {
            get => physicians;
            private set
            {
                physicians = value;
                NotifyPropertyChanged();
            }
        }

        public void LoadPhysicians()
        {
            var filteredPhysicians = PhysicianServiceProxy.Current.Physicians
                .Where(p => string.IsNullOrEmpty(Query) ||
                           p.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ||
                           p.Specialization.ToUpper().Contains(Query?.ToUpper() ?? string.Empty))
                .OrderBy(p => p.Name)
                .Take(100)
                .Select(p => new PhysicianViewModel(p))
                .ToList();

            Physicians.Clear();
            foreach (var physician in filteredPhysicians)
            {
                Physicians.Add(physician);
            }
        }

        public void Delete()
        {
            if (SelectedPhysician?.Model != null)
            {
                PhysicianServiceProxy.Current.DeletePhysician(SelectedPhysician.Model.licenseNum);
                Refresh();
            }
        }

        public void Refresh()
        {
            LoadPhysicians();
        }

        public PhysicianManagementViewModel()
        {
            physicians = new ObservableCollection<PhysicianViewModel>();
            Query = string.Empty;
            LoadPhysicians();
        }
    }


}