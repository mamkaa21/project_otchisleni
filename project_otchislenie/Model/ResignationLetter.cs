﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie.Model
{
    public class ResignationLetter
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int StudentId { get; set; }

        public Student Student { get; private set; }

        public override string ToString()
        {

            return $"{Reason}, {Date}, {Student?.LastName}";
        }

        public async void SetStudent()
        {
            Student = await DB.GetInstance().GetStudentById(StudentId);
        }
    }
}