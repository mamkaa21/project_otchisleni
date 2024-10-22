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
    [QueryProperty(nameof(ResignationLetter), "ResignationLetter")]
    public class EditLetterPageVM : BaseVM
    {
        private ResignationLetter resignationLetter;

        public ResignationLetter ResignationLetter
        {
            get => resignationLetter;
            set
            {
                resignationLetter = value;
                Signal();
            }
        }

        public List<string> Reasons { get; set; }
        public Student Student { get; set; }
        public List<Student> Students { get; set; }

        public CommandVM SaveLetter { get; }

        public EditLetterPageVM()
        {
            Reasons = new List<string> { "По собственному желанию", "Академическая задолженность" };
            GetStudents();
            SaveLetter = new CommandVM(async () =>
            {
                if (Student != null)
                {
                    ResignationLetter.StudentId = Student.Id;
                }
                if (ResignationLetter.Id != 0)
                {
                    await DB.GetInstance().EditResignationLetter(ResignationLetter);
                    Signal();

                }
                await Shell.Current.GoToAsync("//MainPage");
            });
        }
        private async void GetStudents()
        {
            Students = await DB.GetInstance().GetListStudent();
            if (ResignationLetter.StudentId != 0)
            {
                Student = Students.FirstOrDefault(s => s.Id == ResignationLetter.StudentId);
            }
            Signal();
        }
    }
}
