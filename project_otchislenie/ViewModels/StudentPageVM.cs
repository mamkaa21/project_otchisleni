using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    public class StudentPageVM : BaseVM
    {
        public List<Student> Students { get; set; }
        public Student Student { get; set; }
        public CommandVM EditStudent { get; }
        public CommandVM DeleteStudent { get; }
        public StudentPageVM()
        {
            
            EditStudent = new CommandVM(async () =>
            {
                if (Student == null)
                    return;
                else
                {
                    ShellNavigationQueryParameters shellQuery = new ShellNavigationQueryParameters()
                    {
                        {"Student", Student }
                    };
                    await Shell.Current.GoToAsync("Student", shellQuery);
                }

            });
            DeleteStudent = new CommandVM(async () =>
            {
                if (Student == null)
                    return;
                else
                {
                    DB.GetInstance().DeleteStudent();
                    GetData();
                }
            });
        }
        internal void OnAppearing()
        {
            GetData();
        }
        private async void GetData()
        {
            DB.GetInstance().GetListStudent();
            Signal(nameof(Students));
        }
    }
}
