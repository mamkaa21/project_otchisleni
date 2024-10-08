using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace project_otchislenie;

public partial class EditStudentPage : ContentPage
{

    public Student Student { get; set; }

    private DB DB;


    public EditStudentPage(Student student, DB dB)
    {
        InitializeComponent();
        DB = dB;
        Student = student;
        BindingContext = this;
    }

    private async void SaveStudent(object sender, EventArgs e)
    {
        if (Student.Id != 0)
        {
            await DB.EditStudent(Student);
            OnPropertyChanged(nameof(Student));
            await Navigation.PopAsync();
        }
    }

    private void AgeChanged(object sender, ValueChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Student));
    }
}