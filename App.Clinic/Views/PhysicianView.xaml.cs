using App.Clinic.ViewModels;
using Library.Clinic.Models;
using Library.Clinic.Services;

namespace App.Clinic.Views;

[QueryProperty(nameof(LicenseNum), "licenseNum")]
public partial class PhysicianView : ContentPage
{
    public PhysicianView()
    {
        InitializeComponent();
    }

    public int LicenseNum { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Physicians");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysicianViewModel)?.ExecuteAdd();
    }

    private void PhysicianView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (LicenseNum > 0)
        {
            var model = PhysicianServiceProxy.Physicians
                .FirstOrDefault(p => p.licenseNum == LicenseNum);
            if (model != null)
            {
                BindingContext = new PhysicianViewModel(model);
            }
            else
            {
                BindingContext = new PhysicianViewModel();
            }
        }
        else
        {
            BindingContext = new PhysicianViewModel();
        }
    }
}