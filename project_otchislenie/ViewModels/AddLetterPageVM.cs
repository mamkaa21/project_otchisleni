using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    public class AddLetterPageVM : BaseVM
    {
        public Resignationletter Resignationletter { get; set; } = new Resignationletter();
        public List<string> Reasons { get; set; }
        public Student Student { get; set; }
        public List<Student> Students { get; set; }

        public CommandVM AddLetter { get; }

        public AddLetterPageVM()
        {
            GetStudents();
            Reasons = new List<string>(new string[] { "По собственному желанию", "Академическая задолженность" });
            AddLetter = new CommandVM(async () =>
            {
                if (Student != null)
                {
                    Resignationletter.IdStudent = Student.Id;
                }
                await DB.GetInstance().AddResignationletter();
                Signal(nameof(Resignationletter));
                await Shell.Current.GoToAsync("//MainPage");
            });

        }

        public async void GetStudents()
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

            Resignationletter = new Resignationletter();
            Students = new List<Student>();
            Signal(nameof(Students));
            GetStudents();
            Signal(nameof(Resignationletter));

        }
    }
}
