
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_otchislenie.Models;

namespace project_otchislenie
{
    public class DB
    {
        private PpkDB context = new PpkDB("deathnote");
        private static DB instance;

        private List<Resignationletter> Resignationletters { get; set; }
        private List<Student> Students { get; set; }
        private Student Student { get; set; }
        private Resignationletter Resignationletter { get; set; }
        private User User { get; set; }
        private List<User> Users { get; set; }

        private int LastIdStudent = 1;
        private int LastResignationletterId = 1;
        private int LastUserId = 1;


        public DB()
        {
            
            context.Database.EnsureCreated();
            //context.Students.Add(new Student
            //{
            //    Firstname = "Мария",
            //    Lastname = "Розина",
            //    Age = 18,
            //    Debts = 0
            //});
            

            //context.Resignationletters.Add(new Resignationletter
            //{
            //    Reason = "По собственному желанию",
            //    Date = new DateTime(2024, 9, 30, 17, 40, 20),
            //    IdStudent = 1
            //});
            

            //context.Users.Add(new User
            //{
            //    Login = "d",
            //    Password = "d"
            //});
            

        }
        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }
        public async Task<List<User>> GetUsers()
        {
            await Task.Delay(100);
            return new List<User>(context.Users.ToList());
        }

        public async Task<List<Resignationletter>> GetListResignationletter()
        {
            await Task.Delay(100);
            foreach (var item in context.Resignationletters)
            {
                item.SetStudent();
            }
            return new List<Resignationletter>(context.Resignationletters.ToList());
        }

        public async Task<List<Student>> GetListStudent()
        {
            await Task.Delay(100);
            return new List<Student>(context.Students.ToList());
        }

        public async Task<Resignationletter> GetResignationletterById(int id)
        {
            await Task.Delay(100);
            var letter = context.Resignationletters.FirstOrDefault(s => s.Id == id);
            if (letter == null)
            {
                return null;
            }
            Resignationletter getResignationletter = new Resignationletter()
            {
                Id = letter.Id,
                Reason = letter.Reason,
                Date = letter.Date,
                IdStudent = letter.IdStudent,
            };
            return getResignationletter;
        }

        public async Task<Student> GetStudentById(int? id)
        {

            var student = context.Students.FirstOrDefault(s => s.Id == id);
            await Task.Delay(100);
            if (student == null)
            {
                return null;
            }
            Student getStudent = new Student()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Age = student.Age,
                Debts = student.Debts
            };
            return getStudent;
        }

        public async Task AddResignationletter(Resignationletter Resignationletter)
        {
            await Task.Delay(100);
            Resignationletter newResignationletter = new Resignationletter()
            {
                Reason = Resignationletter.Reason,
                Date = Resignationletter.Date,
                IdStudent = Resignationletter.IdStudent

            };
            await context.Resignationletters.AddAsync(newResignationletter);
            await context.SaveChangesAsync();
        }

        public async Task AddUser(User user)
        {
            await Task.Delay(100);
            User newuser = new User()
            {
                Login = user.Login,
                Password = user.Password
            };
            await context.Users.AddAsync(newuser);
            await context.SaveChangesAsync();
        }

        public async Task AddStudent(Student student)
        {
            await Task.Delay(100);
            Student getStudent = new Student()
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Age = student.Age,
                Debts = student.Debts
            };
            await context.Students.AddAsync(getStudent);
            await context.SaveChangesAsync();
        }

        public async Task EditResignationletter(Resignationletter Resignationletter)
        {
            await Task.Delay(100);
            var letter = context.Resignationletters.FirstOrDefault(s => s.Id == Resignationletter.Id);
            letter.Id = Resignationletter.Id;
            letter.Reason = Resignationletter.Reason;
            letter.Date = Resignationletter.Date;
            letter.IdStudent = Resignationletter.IdStudent;
            await context.SaveChangesAsync();
        }

        public async Task EditStudent(Student student)
        {
            await Task.Delay(100);
            var stu = context.Students.FirstOrDefault(s => s.Id == student.Id);
            stu.Id = student.Id;
            stu.Firstname = student.Firstname;
            stu.Lastname = student.Lastname;
            stu.Age = student.Age;
            await context.SaveChangesAsync();
        }

        public async Task DeleteResignationletterById(Resignationletter Resignationletter)
        {
            await Task.Delay(100);
            var letter = context.Resignationletters.FirstOrDefault(s => s.Id == Resignationletter.Id);
            if (Resignationletter.Id == letter.Id)
            {
                context.Resignationletters.Remove(Resignationletter);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteStudent(Student student)
        {
            await Task.Delay(100);
            var stu = context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (student.Id == stu.Id)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
            }
        }

    }
}

