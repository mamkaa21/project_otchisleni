using System.ComponentModel;
using project_otchislenie.ViewModels;
using project_otchislenie.Models;

namespace project_otchislenie.Views
{
    public partial class StudentPage : ContentPage
    {
        

        public StudentPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ((StudentPageVM)BindingContext).OnAppearing();
            
        }

       
    }
}
