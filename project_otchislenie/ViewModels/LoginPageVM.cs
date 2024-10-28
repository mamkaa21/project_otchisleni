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
        public List<User> Users { get; set; }

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
                Users = await DB.GetInstance().GetUsers();
                var user = Users.FirstOrDefault(s => s.Login == Login && s.Password == Password);

                if (user != null)
                {
                    Login = "";
                    Password = "";
                    Signal(nameof(Users));
                    await Shell.Current.GoToAsync("//MainPage");
                    Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong Login or Password", "Ok");
                }
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
