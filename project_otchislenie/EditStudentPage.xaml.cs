using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace project_otchislenie;

public partial class EditStudentPage : ContentPage
{
    public Student Student { get; set; }

    public EditStudentPage(Student student)
    {
        InitializeComponent();
        Student = student;
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