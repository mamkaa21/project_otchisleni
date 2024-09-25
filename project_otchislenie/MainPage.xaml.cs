﻿using System.Collections.Specialized;
using System.ComponentModel;

namespace project_otchislenie
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private Student selectedStudents;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Student> Students { get; set; }

        public Student SelectedStudents
        {
            get => selectedStudents;
            set
            {
                selectedStudents = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedStudents)));
            }
        }
        private DB DB;

        public MainPage()
        {
            InitializeComponent();
            //Students = new List<Student>();
            //Students.Add(new Student
            //{
            //    FirstName = "Мария",
            //    LastName = "Розина",
            //    Age = 18
            //});
        }

        private async void OpenListStudent(object sender, EventArgs e)
        {
             await DB.GetListStudent();
            await Navigation.PushAsync(new StudentPage());
        }
    }

}
