namespace project_otchislenie;

public partial class LoginPage : ContentPage
{
	public string Login {  get; set; }
	public string Password { get; set; }
	public List<User> Users { get; set; }
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = this;
		Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
	}
	
	public async void EntryButton(object sender, EventArgs e)
	{
		Users = await DB.GetInstance().GetUsers();
		var user = Users.FirstOrDefault(s => s.Login == Login && s.Password == Password);
		if (user != null)
		{
			Shell.Current.GoToAsync("//MainPage");
			Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
		}
		else
		{
			await DisplayAlert("Error", "Wrong Login or Password", "Ok");

		}
	}

    
}