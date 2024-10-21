using project_otchislenie.Model;

namespace project_otchislenie.View
{



    public partial class LoginPage : ContentPage
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<User> Users { get; set; }

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;

        }

        protected override void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;

        }

        public async void EntryButton(object sender, EventArgs e)
        {
            Users = await DB.GetInstance().GetUsers();
            var user = Users.FirstOrDefault(s => s.Login == Login && s.Password == Password);
            if (user != null)
            {
                Login = "";
                Password = "";
                OnPropertyChanged(nameof(Login));
                OnPropertyChanged(nameof(Password));
                await Shell.Current.GoToAsync("//MainPage");
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            }
            else
            {
                await DisplayAlert("Error", "Wrong Login or Password", "Ok");

            }
        }

        public async void OpenRegistrationPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegistrationPage");
        }
    }
}