using System.Collections.ObjectModel;
using System.ComponentModel;
using project_otchislenie.Model;

namespace project_otchislenie.View
{
    public partial class AddStudentPage : ContentPage
    {
        public Student Student { get; set; }



        public AddStudentPage()
        {
            InitializeComponent();
            Student = new Student();
            BindingContext = this;
        }

        private async void SaveStudent(object sender, EventArgs e)
        {
            await DB.GetInstance().AddStudent(Student);
            OnPropertyChanged(nameof(Student));
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


