namespace project_otchislenie;

public partial class EditLetterPage : ContentPage
{
	public ResignationLetter ResignationLetter { get; set; }
    private DB DB;

    public EditLetterPage(ResignationLetter resignationLetter, DB db)
	{
		InitializeComponent();
        DB = db;
        ResignationLetter = resignationLetter;
        BindingContext = this;

    }
    private async void SaveLetter(object sender, EventArgs e)
    {
        if (ResignationLetter.Id != 0)
        {
            await DB.EditResignationLetter(ResignationLetter);
            OnPropertyChanged(nameof(ResignationLetter));
            await Navigation.PopAsync();
        }
    }
}