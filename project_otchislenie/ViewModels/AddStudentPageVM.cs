using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    public class AddStudentPageVM : BaseVM
    {
        public Student Student { get; set; }
        public CommandVM SaveStudent { get; }

        public AddStudentPageVM()
        {
            SaveStudent = new CommandVM(async () =>
            {
                if (Student == null)
                {
                    Student = new Student();
                }
                else
                {
                    await DB.GetInstance().AddStudent(Student);
                    Signal();
                    await Shell.Current.GoToAsync("StudentPage");
                }
            });
        }
    }
}
