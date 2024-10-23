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
        public CommandVM AddUser { get; }

        public RegistrationPageVM()
        {
            AddUser = new CommandVM( async () =>
            {
                    await DB.GetInstance().AddUser(User);
                    Signal(nameof(User));
                    await Shell.Current.GoToAsync("//LoginPage");
            });
        }
        internal void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }
}
