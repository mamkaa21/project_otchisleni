using project_otchislenie.Models;
using project_otchislenie.ViewModels;

namespace project_otchislenie.Views
{
    public partial class LoginPage : ContentPage
    {
        

        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ((LoginPageVM)BindingContext).OnAppearing();

        }

       
    }
}