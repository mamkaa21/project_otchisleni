using Microsoft.Maui.Controls;
using project_otchislenie.Model;
using System.ComponentModel;

namespace project_otchislenie.View
{


    [QueryProperty(nameof(Student), "Student")]
    public partial class EditStudentPage : ContentPage
    {
        private Student student;
        public Student Student
        {
            get => student;
            set
            {
                student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        public EditStudentPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private async void SaveStudent(object sender, EventArgs e)
        {
            if (Student.Id != 0)
            {
                await DB.GetInstance().EditStudent(Student);
                OnPropertyChanged(nameof(Student));
            }
            await Navigation.PopAsync();
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