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
    [QueryProperty(nameof(Student), "Student")]
    public class EditStudentPageVM : BaseVM
    {
        private Student student;
        public Student Student
        {
            get => student;
            set
            {
                student = value;
                Signal();
            }
        }

        public CommandVM SaveStudent { get; }
        public EditStudentPageVM()
        {
            SaveStudent = new CommandVM(async () =>
            {
                if (Student.Id != 0)
                {
                    await DB.GetInstance().EditStudent(Student);
                    Signal();
                }
                await Shell.Current.GoToAsync("StudentPage");
            });

        }

        private void AgeChanged(object sender, ValueChangedEventArgs e)
        {
            Signal();
        }

        private void DebtsChanged(object sender, ValueChangedEventArgs e)
        {
            Signal(nameof(Student));
        }

        internal void StepperChanged()
        {
            
        }
    }
}
