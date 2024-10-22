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
        }


        private void AgeChanged(object sender, ValueChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Student));
        }

        private void DebtsChanged(object sender, ValueChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Student));
        }
    }
}


