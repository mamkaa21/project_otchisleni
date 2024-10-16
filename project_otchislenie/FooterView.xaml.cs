namespace project_otchislenie;

public partial class FooterView : ContentView
{
	public FooterView()
	{
		InitializeComponent();
	}

    private async void Exit(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
    }
}