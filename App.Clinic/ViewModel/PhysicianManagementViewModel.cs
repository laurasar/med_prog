using Library.Clinic.Models;
using Library.Clinic.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.Clinic.ViewModels
{
    public class PhysicianManagementViewModel : INotifyPropertyChanged
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
                    NotifyPropertyChanged(nameof(Physicians));
                }
            }
        }


        public ObservableCollection<PhysicianViewModel> Physicians
        {
            get
            {
                var physicians = PhysicianServiceProxy.Physicians
                    .Where(p => string.IsNullOrEmpty(Query) ||
                               p.Name.ToUpper().Contains(Query.ToUpper()) ||
                               p.Specialization.ToUpper().Contains(Query.ToUpper()))
                    .OrderBy(p => p.Name)
                    .Take(100)
                    .Select(p => new PhysicianViewModel(p))
                    .ToList();

                return new ObservableCollection<PhysicianViewModel>(physicians);
            }
        }

        public void Delete()
        {
            if (SelectedPhysician?.Model != null)
            {
                PhysicianServiceProxy.DeletePhysician(SelectedPhysician.Model.licenseNum);
                Refresh();
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Physicians));
        }

        public PhysicianManagementViewModel()
        {
            // Initialize any required properties
            Query = string.Empty;
        }
    }
}