using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    public class LoginPageVM : BaseVM
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public User User { get; set; } =  new User();

        public CommandVM OpenRegistrationPage { get; }
        public CommandVM EntryButton { get; }
        public LoginPageVM() 
        {
            
            OpenRegistrationPage = new CommandVM(async() =>
            {
                await Shell.Current.GoToAsync("RegistrationPage");
            });
            EntryButton = new CommandVM(async () =>
            {
                var check =  await DB.GetInstance().CheckLoginPassword(User);

                if (check != null)
                {
                    Login = "";
                    Password = "";
                    Signal(nameof(User));
                    await Shell.Current.GoToAsync("//MainPage");
                    Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong Login or Password", "Ok");
            });
        }
        internal async void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
            Signal(nameof(Login));
            Signal(nameof(Password));   
        }
    }
}
