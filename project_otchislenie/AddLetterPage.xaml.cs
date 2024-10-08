using System.Diagnostics;

namespace project_otchislenie;

public partial class AddLetterPage : ContentPage
{
	public ResignationLetter ResignationLetter { get; set; }
    public List<string> Reasons { get; set; }
    public Student Student { get; set; }
    public List<Student> Students { get; set; }

    private DB DB;


    public AddLetterPage(DB dB)
	{
		InitializeComponent();
		DB = dB;
        ResignationLetter = new ResignationLetter();
        Reasons = new List<string>(new string[] {"По собственному желанию", "Академическая задолженность" });
        GetStudents();
        BindingContext = this;
    }

    private async void GetStudents()
    {
        //Debug.WriteLine("ыыыы");

        Students = await DB.GetListStudent();
        OnPropertyChanged(nameof(Students));
    }

    private async void SaveLetter(object sender, EventArgs e)
    {
        if (ResignationLetter.Id == 0)
        {
            await DB.AddResignationLetter(ResignationLetter);
        }
        else
        {
            await DB.EditResignationLetter(ResignationLetter);
        }
        OnPropertyChanged(nameof(ResignationLetter));
        await Navigation.PopAsync();
    }
}