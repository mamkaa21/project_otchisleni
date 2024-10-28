using System.Collections.ObjectModel;
using System.ComponentModel;
using project_otchislenie.ViewModels;
using project_otchislenie.Models;

namespace project_otchislenie.Views
{
    public partial class AddStudentPage : ContentPage
    {
        public AddStudentPage()
        {
            InitializeComponent();
            BindingContext = new AddStudentPageVM();
        }


        private void AgeChanged(object sender, ValueChangedEventArgs e)
        {
            ((AddStudentPageVM)BindingContext).StepperChanged();
        }

        private void DebtsChanged(object sender, ValueChangedEventArgs e)
        {
            ((AddStudentPageVM)BindingContext).SliderChanged();
        }

        protected override void OnAppearing()
        {
            ((AddStudentPageVM)BindingContext).OnAppearing();
        }
    }
}


