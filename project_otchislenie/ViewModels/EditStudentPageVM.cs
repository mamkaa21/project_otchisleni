using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    [QueryProperty(nameof(Student), "Student")]
    public class EditStudentPageVM : BaseVM, INotifyPropertyChanged
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
                    await DB.GetInstance().EditStudent();
                    Signal(nameof(Student));
                }
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
    }
}
