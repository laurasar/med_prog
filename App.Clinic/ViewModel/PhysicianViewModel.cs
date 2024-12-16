using Library.Clinic.Models;
using Library.Clinic.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace App.Clinic.ViewModels
{
    public class PhysicianViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Physician? Model { get; set; }
        public ICommand? DeleteCommand { get; set; }
        public ICommand? EditCommand { get; set; }

        public bool IsNew => Model?.licenseNum <= 0;

        public int LicenseNum
        {
            get => Model?.licenseNum ?? 0;
            set
            {
                if (Model != null && Model.licenseNum != value)
                {
                    Model.licenseNum = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => Model?.Name ?? string.Empty;
            set
            {
                if (Model != null && Model.Name != value)
                {
                    Model.Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Specialization
        {
            get => Model?.Specialization ?? string.Empty;
            set
            {
                if (Model != null && Model.Specialization != value)
                {
                    Model.Specialization = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime GraduationDate
        {
            get => Model?.gradDate ?? DateTime.MinValue;
            set
            {
                if (Model != null)
                {
                    Model.gradDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(DoDelete);
            EditCommand = new Command((p) => DoEdit(p as PhysicianViewModel));
        }

        private void DoDelete()
        {
            if (Model != null && Model.licenseNum > 0)
            {
                PhysicianServiceProxy.DeletePhysician(Model.licenseNum);
                Shell.Current.GoToAsync("//Physicians");
            }
        }

        private void DoEdit(PhysicianViewModel? pvm)
        {
            if (pvm?.Model?.licenseNum > 0)
            {
                Shell.Current.GoToAsync($"//PhysicianDetails?licenseNum={pvm.Model.licenseNum}");
            }
        }

        public string Display
        {
            get
            {
                if (Model == null) return string.Empty;
                return $"Dr. {Model.Name} - {Model.Specialization} (License: {Model.licenseNum})";
            }
        }

        public PhysicianViewModel()
        {
            Model = new Physician();
            SetupCommands();
        }

        public PhysicianViewModel(Physician? model)
        {
            Model = model ?? new Physician();
            SetupCommands();
        }

        public void ExecuteAdd()
        {
            if (Model != null)
            {
                if (Model.licenseNum <= 0)
                {
                    PhysicianServiceProxy.AddPhysician(Model);
                }
                else
                {
                    PhysicianServiceProxy.UpdatePhysician(Model);
                }
                Shell.Current.GoToAsync("//Physicians");
            }
        }

        public bool Validate()
        {
            if (Model == null) return false;

            // Basic validation rules
            if (string.IsNullOrWhiteSpace(Model.Name)) return false;
            if (string.IsNullOrWhiteSpace(Model.Specialization)) return false;
            if (Model.gradDate == DateTime.MinValue) return false;

            // License number should be positive when adding/updating
            if (!IsNew && Model.licenseNum <= 0) return false;

            return true;
        }
    }
}