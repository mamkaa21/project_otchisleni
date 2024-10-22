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
        public User User { get; set; }
        public CommandVM AddUser { get; }

        public RegistrationPageVM()
        {
            AddUser = new CommandVM( async () =>
            {
                if (User == null)
                {
                    User = new User();
                }
                else
                {
                    await DB.GetInstance().AddUser(User);
                    Signal();
                    Shell.Current.GoToAsync("//LoginPage");
                    Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                }
            });
        }
        internal void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }
}
