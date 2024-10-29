using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    public class RegistrationPageVM : BaseVM
    {
        public User User { get; set; } = new User();
        public List<User> Users { get; set; }
        public CommandVM AddUser { get; }

        public RegistrationPageVM()
        {
            AddUser = new CommandVM( async () =>
            {
                Users = await DB.GetInstance().GetUsers();
                var find = Users.FirstOrDefault(s => s.Login == User.Login);
                Signal(nameof(Users));
                if (find != null)
                {
                    await Application.Current.MainPage.DisplayAlert("шибюка", "Такой пользователь уже существует", "ок");         
                }
                else
                {
                    await DB.GetInstance().AddUser(User);
                    Signal(nameof(User));
                    await Shell.Current.GoToAsync("//LoginPage");
                }
               
            });
        }
        internal void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
            Signal(nameof(User));
            Signal(nameof(Users));
        }
    }
}
