namespace project_otchislenie;

public partial class EditLetterPage : ContentPage
{
    public ResignationLetter ResignationLetter { get; set; }
    public List<string> Reasons { get; set; }
    public Student Student { get; set; }
    public List<Student> Students { get; set; }

    private DB DB;

    public EditLetterPage(ResignationLetter resignationLetter, DB db)
	{
		InitializeComponent();
        DB = db;
        ResignationLetter = resignationLetter;
        Reasons = new List<string>(new string[] { "По собственному желанию", "Академическая задолженность" });
        GetStudents();
        BindingContext = this;

    }
    private async void GetStudents()
    {
        Students = await DB.GetListStudent();
        if (ResignationLetter.Student != null)
        {
            Student = Students.FirstOrDefault(s => s.Id == ResignationLetter.StudentId);
        }
        OnPropertyChanged(nameof(Students));
        OnPropertyChanged(nameof(Student));
    }
    private async void SaveLetter(object sender, EventArgs e)
    {
        if (Student != null)
        {
            ResignationLetter.Student = Student;
            ResignationLetter.StudentId = ResignationLetter.Student.Id;
        }
        if (ResignationLetter.Id != 0)
        {
            await DB.EditResignationLetter(ResignationLetter);
            OnPropertyChanged(nameof(ResignationLetter));

        }
        await Navigation.PopAsync();
    }
}