using project_otchislenie.Model;

namespace project_otchislenie.View
{


    public partial class RegistrationPage : ContentPage
    {
        public User User { get; set; }

        public RegistrationPage()
        {
            InitializeComponent();
            User = new User();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;

        }

        private async void EntryButton(object sender, EventArgs e)
        {
            await DB.GetInstance().AddUser(User);
            OnPropertyChanged(nameof(User));
            Shell.Current.GoToAsync("//LoginPage");
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }
    }
}
