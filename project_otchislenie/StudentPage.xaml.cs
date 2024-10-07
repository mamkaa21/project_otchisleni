using System.ComponentModel;

namespace project_otchislenie;

public partial class StudentPage : ContentPage
{
    public List<Student> Students { get; set; }
    public Student Student { get; set; }
    private DB DB = new();
    bool loaded = false;

    public StudentPage()
	{
        InitializeComponent();
        GetData();
        BindingContext = this;  
	}

    protected override void OnAppearing()
    {
            GetData();
    }

    private async void GetData()
    {
        Students = await DB.GetListStudent();
        OnPropertyChanged(nameof(Students));
    }

    private async void AddStudent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddStudentPage(DB));
        GetData();
    }

    private async void EditStudent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditStudentPage(Student, DB));
    }

    private async void DeleteStudent(object sender, EventArgs e)
    {
        await DB.DeleteStudent(Student);
        GetData();

    }
}