

using project_otchislenie.ViewModels;
using project_otchislenie.Models;

namespace project_otchislenie.Views
{


    public partial class RegistrationPage : ContentPage
    {
      

        public RegistrationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
           ((RegistrationPageVM)BindingContext).OnAppearing();

        }

        
    }
}