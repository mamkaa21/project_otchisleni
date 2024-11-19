using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    public class UserPageVM : BaseVM
    {
        private User user;
        public User User 
        { 
            get=> user;
            set 
            { 
                user = value;
                Signal(nameof(User));
            }
        }
       


        public CommandVM SavePassword { get; }

        public UserPageVM()
        {
            User = AppShell.User;
            SavePassword = new CommandVM(async () =>
            {
                
                await DB.GetInstance().EditUserPassword(User);
                Signal(nameof(User));
                await Shell.Current.GoToAsync("//MainPage");

            });

        }
    }
}
