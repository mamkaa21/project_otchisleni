
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project_otchislenie
{
    public class DB
    {
        public List<ResignationLetter> ResignationLetters { get; set; }
        public List<Student> Students { get; set; }
        public Student Student { get; set; }
        public ResignationLetter ResignationLetter { get; set; }

        private int LastStudentId = 0;
        private int LastResignationLetterId = 0;

        public DB()
        {
            Students = new List<Student>();
            Students.Add(new Student
            {
                Id = 0,
                FirstName = "Мария",
                LastName = "Розина",
                Age = 18,
                Debts = 0
            });
            ResignationLetters = new List<ResignationLetter>();
            ResignationLetters.Add(new ResignationLetter
            {
                Id = 0,
                Reason = "По собственному желанию",
                Date = new DateTime(2024, 9, 30, 17, 40, 20),
                StudentId = 0
            });
        }

        public async Task<List<ResignationLetter>> GetListResignationLetter()
        {
            await Task.Delay(100);
            return new List<ResignationLetter>(ResignationLetters);
        }

        public async Task<List<Student>> GetListStudent()
        {
            await Task.Delay(100);
            return new List<Student>(Students);
        }

        public async Task<ResignationLetter> GetResignationLetterById(int id)
        {
            await Task.Delay(100);
            var letter = ResignationLetters.FirstOrDefault(s => s.Id == id);
            if (letter == null)
            {
                return null;
            }
            ResignationLetter getResignationLetter = new ResignationLetter()
            {
                Id = letter.Id,
                Reason = letter.Reason,
                Date = letter.Date,
                StudentId = letter.StudentId,
            };
            return getResignationLetter;
        }

        public async Task<Student> GetStudentById(int id)
        {

            var student = Students.FirstOrDefault(s => s.Id == id);
            await Task.Delay(100);
            if (student == null)
            {
                return null;
            }
            Student getStudent = new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Debts = student.Debts
            };
            return getStudent;
        }

        public async Task AddResignationLetter(ResignationLetter resignationLetter)
        {
            await Task.Delay(100);
            ResignationLetter newResignationLetter = new ResignationLetter()
            {
                Id = ++LastResignationLetterId,
                Reason = resignationLetter.Reason,
                Date = resignationLetter.Date,
                StudentId= resignationLetter.StudentId

            };
            ResignationLetters.Add(newResignationLetter);
        }

        public async Task AddStudent(Student student)
        {
            await Task.Delay(100);
            Student getStudent = new Student()
            {
                Id = ++LastStudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Debts = student.Debts
            };
            Students.Add(getStudent);
        }

        public async Task EditResignationLetter(ResignationLetter resignationLetter)
        {
            await Task.Delay(100);
            var letter = ResignationLetters.FirstOrDefault(s => s.Id == resignationLetter.Id);
            letter.Id = resignationLetter.Id;
            letter.Reason = resignationLetter.Reason;
            letter.Date = resignationLetter.Date;
            letter.StudentId = resignationLetter.StudentId;
        }

        public async Task EditStudent(Student student)
        {
            await Task.Delay(100);
            var stu = Students.FirstOrDefault(s => s.Id == student.Id);
            stu.Id = student.Id;
            stu.FirstName = student.FirstName;
            stu.LastName = student.LastName;
            stu.Age = student.Age;
        }

        public async Task DeleteResignationLetterById(ResignationLetter resignationLetter)
        {
            await Task.Delay(100);
            var letter = ResignationLetters.FirstOrDefault(s => s.Id == resignationLetter.Id);
            if (resignationLetter.Id == letter.Id)
            {
                ResignationLetters.Remove(resignationLetter);
            }
        }

        public async Task DeleteStudent(Student student)
        {
            await Task.Delay(100);
            var stu = Students.FirstOrDefault(s => s.Id == student.Id);
            if (student.Id == stu.Id)
            {
                Students.Remove(student);
            }
        }

    }
}

