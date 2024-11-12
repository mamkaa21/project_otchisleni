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
    [QueryProperty(nameof(Resignationletter), "Resignationletter")]
    public class EditLetterPageVM : BaseVM
    {
        private Resignationletter resignationletter;

        public Resignationletter Resignationletter
        {
            get => resignationletter;
            set
            {
                resignationletter = value;
                GetStudents();
                Signal(nameof(Resignationletter));
            }
        }

        public List<string> Reasons { get; set; }

        private Student student;
        public Student Student
        {
            get => student;
            set
            {
                student = value;
                Signal(nameof(Student));
            }
        }

        public List<Student> Students { get; set; }

        public CommandVM SaveLetter { get; }

        public EditLetterPageVM()
        {
            Reasons = new List<string> { "По собственному желанию", "Академическая задолженность" };
            SaveLetter = new CommandVM(async () =>
            {
                if (Student != null)
                {
                    Resignationletter.IdStudent = Student.Id;
                }
                if (Resignationletter.Id != 0)
                {
                    await DB.GetInstance().EditResignationletter();
                    Signal(nameof(Resignationletter));

                }
                await Shell.Current.GoToAsync("//MainPage");
            });
        }
        private async void GetStudents()
        {
            await DB.GetInstance().GetListStudent();
            if (Resignationletter.IdStudent != 0)
            {
                Student = Students.FirstOrDefault(s => s.Id == Resignationletter.IdStudent);
            }
            Signal(nameof(Students));
        }
        internal void OnAppearing()
        {
            GetStudents();
        }
    }
}
