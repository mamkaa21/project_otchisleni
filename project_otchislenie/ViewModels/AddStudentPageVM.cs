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
        public Student Student { get; set; } =  new Student();
        public CommandVM SaveStudent { get; }

        public AddStudentPageVM()
        {
            SaveStudent = new CommandVM(async () =>
            {
                    DB.GetInstance().AddStudent();
                    Signal(nameof(Student));
                    await Shell.Current.GoToAsync("//StudentPage");
              
            });
        }
        internal void StepperChanged()
        {
            Signal(nameof(Student));
        }
        internal void SliderChanged()
        {
            Signal(nameof(Student));
        }
        internal void OnAppearing()
        {
            Student = new Student();
            Signal(nameof(Student));
        }
    }
}
