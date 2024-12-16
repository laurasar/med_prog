using App.Clinic.ViewModels;

namespace App.Clinic.Views;

public partial class PhysicianManagementView : ContentPage
{
    public PhysicianManagementView()
    {
        InitializeComponent();
        BindingContext = new PhysicianManagementViewModel();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PhysicianDetails?licenseNum=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var selectedLicenseNum = (BindingContext as PhysicianManagementViewModel)?
            .SelectedPhysician?.LicenseNum ?? 0;
        Shell.Current.GoToAsync($"//PhysicianDetails?licenseNum={selectedLicenseNum}");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysicianManagementViewModel)?.Delete();
    }

    private void PhysicianManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PhysicianManagementViewModel)?.Refresh();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysicianManagementViewModel)?.Refresh();
    }
}