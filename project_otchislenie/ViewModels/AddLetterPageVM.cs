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
        public ResignationLetter ResignationLetter { get; set; }
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
                    ResignationLetter.StudentId = Student.Id;
                }

                if (ResignationLetter == null)
                {
                    ResignationLetter = new ResignationLetter();
                }
                else
                {
                    await DB.GetInstance().AddResignationLetter(ResignationLetter);
                    Signal();
                }
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
