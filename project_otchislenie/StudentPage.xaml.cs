using System.ComponentModel;

namespace project_otchislenie;

public partial class StudentPage : ContentPage
{
    public List<Student> Students { get; set; }
    public Student Student { get; set; }

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
        Students = await DB.GetInstance().GetListStudent();
        OnPropertyChanged(nameof(Students));
    }

    private async void AddStudent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddStudentPage());
        GetData();
    }

    private async void EditStudent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditStudentPage(Student));
    }

    private async void DeleteStudent(object sender, EventArgs e)
    {
        await DB.GetInstance().DeleteStudent(Student);
        GetData();

    }
}