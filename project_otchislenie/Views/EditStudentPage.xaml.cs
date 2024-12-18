using Microsoft.Maui.Controls;
using project_otchislenie.ViewModels;
using project_otchislenie.Models;
using System.ComponentModel;

namespace project_otchislenie.Views
{
    public partial class EditStudentPage : ContentPage
    {
        public EditStudentPage()
        {
            InitializeComponent();
            BindingContext = new EditStudentPageVM();
        }

        private void DebtsChanged(object sender, ValueChangedEventArgs e)
        {
            ((EditStudentPageVM)BindingContext).StepperChanged();
        }

        private void AgeChanged(object sender, ValueChangedEventArgs e)
        {
            ((EditStudentPageVM)BindingContext).SliderChanged();
        }
    }
}