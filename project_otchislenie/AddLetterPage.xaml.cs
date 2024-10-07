using System.Diagnostics;

namespace project_otchislenie;

public partial class AddLetterPage : ContentPage
{
	public ResignationLetter ResignationLetter { get; set; }
    public List<string> Reasons { get; set; }
    public Student Student { get; set; }
    public List<Student> Students { get; set; }

    private DB DB = new();


    public AddLetterPage(DB dB)
	{
		InitializeComponent();
		DB = dB;
        ResignationLetter = new ResignationLetter();
        Task.Run(async () => await  GetStudents());
        Reasons = new List<string>(new string[] {"По собственному желанию", "Академическая задолженность" });
        BindingContext = this;
    }

    private async Task GetStudents()
    {
        //Debug.WriteLine("ыыыы");
        Students = await DB.GetListStudent();
        OnPropertyChanged(nameof(Students));
    }

    private async void SaveLetter(object sender, EventArgs e)
    {
        await DB.AddResignationLetter(ResignationLetter);
        OnPropertyChanged(nameof(ResignationLetter));
        await Navigation.PopAsync();
    }
}