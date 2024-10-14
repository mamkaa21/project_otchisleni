using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace project_otchislenie;
[QueryProperty (nameof(Student), "Student")]
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
    
    //private int studentId;
    //public int StudentId { get => studentId; 
    //    set 
    //    {
    //        studentId = value;
    //        GetStudentById(studentId);
    //    } }

    //private async void GetStudentById(int studentId)
    //{
    //    Student = await DB.GetInstance().GetStudentById(studentId);
    //}

    public EditStudentPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    //public async void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    //Student.Id = query["StudentId"] as Student;

    //}
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