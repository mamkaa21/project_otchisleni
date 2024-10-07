using System.Collections.ObjectModel;
using System.ComponentModel;

namespace project_otchislenie;

public partial class AddStudentPage : ContentPage
{
    public Student Student { get; set; }

    private DB DB = new();


    public AddStudentPage(DB dB)
	{
		InitializeComponent();
        DB = dB;
        Student = new Student();
        BindingContext = this;
    }

    private async void SaveStudent(object sender, EventArgs e)
    {
        await DB.AddStudent(Student);
        OnPropertyChanged(nameof(Student));
        await Navigation.PopAsync();

    }

    private void AgeChanged(object sender, ValueChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Student));
    }

    private void DebtsChanged(object sender, ValueChangedEventArgs e)
    {
        OnPropertyChanged(nameof (Student));
    }
}
