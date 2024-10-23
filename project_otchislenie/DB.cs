﻿
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

        private List<ResignationLetter> ResignationLetters { get; set; }
        private List<Student> Students { get; set; }
        private Student Student { get; set; }
        private ResignationLetter ResignationLetter { get; set; }
        private User User { get; set; }
        private List<User> Users { get; set; }

        private int LastStudentId = 1;
        private int LastResignationLetterId = 1;
        private int LastUserId = 1;


        public DB()
        {
            
            context.Database.EnsureCreated();
            context.Students.Add(new Student
            {
                FirstName = "Мария",
                LastName = "Розина",
                Age = 18,
                Debts = 0
            });
            

            context.ResignationLetters.Add(new ResignationLetter
            {
                Reason = "По собственному желанию",
                Date = new DateTime(2024, 9, 30, 17, 40, 20),
                StudentId = 1
            });
            

            context.Users.Add(new User
            {
                Login = "d",
                Password = "d"
            });
            

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

        public async Task<List<ResignationLetter>> GetListResignationLetter()
        {
            await Task.Delay(100);
            foreach (var item in context.ResignationLetters)
            {
                item.SetStudent();
            }
            return new List<ResignationLetter>(context.ResignationLetters.ToList());
        }

        public async Task<List<Student>> GetListStudent()
        {
            await Task.Delay(100);
            return new List<Student>(context.Students.ToList());
        }

        public async Task<ResignationLetter> GetResignationLetterById(int id)
        {
            await Task.Delay(100);
            var letter = context.ResignationLetters.FirstOrDefault(s => s.Id == id);
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

            var student = context.Students.FirstOrDefault(s => s.Id == id);
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
                Reason = resignationLetter.Reason,
                Date = resignationLetter.Date,
                StudentId = resignationLetter.StudentId

            };
            await context.ResignationLetters.AddAsync(newResignationLetter);
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
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Debts = student.Debts
            };
            await context.Students.AddAsync(getStudent);
            await context.SaveChangesAsync();
        }

        public async Task EditResignationLetter(ResignationLetter resignationLetter)
        {
            await Task.Delay(100);
            var letter = context.ResignationLetters.FirstOrDefault(s => s.Id == resignationLetter.Id);
            letter.Id = resignationLetter.Id;
            letter.Reason = resignationLetter.Reason;
            letter.Date = resignationLetter.Date;
            letter.StudentId = resignationLetter.StudentId;
            await context.SaveChangesAsync();
        }

        public async Task EditStudent(Student student)
        {
            await Task.Delay(100);
            var stu = context.Students.FirstOrDefault(s => s.Id == student.Id);
            stu.Id = student.Id;
            stu.FirstName = student.FirstName;
            stu.LastName = student.LastName;
            stu.Age = student.Age;
            await context.SaveChangesAsync();
        }

        public async Task DeleteResignationLetterById(ResignationLetter resignationLetter)
        {
            await Task.Delay(100);
            var letter = context.ResignationLetters.FirstOrDefault(s => s.Id == resignationLetter.Id);
            if (resignationLetter.Id == letter.Id)
            {
                context.ResignationLetters.Remove(resignationLetter);
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

