
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_otchislenie.Models;

namespace project_otchislenie
{
    public class DB
    {
        HttpClient client = new HttpClient();

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
            client.BaseAddress = new Uri("http://10.0.2.2:5246/");
        }
        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }
        public async void GetUsers()
        {
            var responce = await client.GetAsync($"Users/GetUsers");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var users = await responce.Content.ReadFromJsonAsync<List<User>>();
                Users = new List<User>(users);

            }
        }

        public async void GetListResignationletter()
        {
            var responce = await client.GetAsync($"Resignationletters/GetResignationletters");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var letters = await responce.Content.ReadFromJsonAsync<List<Resignationletter>>();
                foreach (var item in letters)
                {
                    item.SetStudent();
                }
                Resignationletters = new List<Resignationletter>(letters);
            }
        }

        public async void GetListStudent()
        {
            var responce = await client.GetAsync($"Students/GetStudents");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var students = await responce.Content.ReadFromJsonAsync<List<Student>>();
                Students = new List<Student>(students);
            }
        }

        public async void GetResignationletterById()
        {
            var responce = await client.GetAsync($"Resignationletters/GetResignationletterById");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var letter = await responce.Content.ReadAsStringAsync();
                return;
            }
        }

        public async void GetStudentById()
        {
            var responce = await client.GetAsync($"Students/GetStudentById");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var letter = await responce.Content.ReadAsStringAsync();
                return;
            }
        }

        public async void AddResignationletter()
        {
            var arg = JsonSerializer.Serialize(Resignationletter);
            var responce = await client.PostAsync($"Resignationletters/AddResignationletter", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async void AddUser()
        {
            var arg = JsonSerializer.Serialize(User);
            var responce = await client.PostAsync($"Users/AddUser", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async void AddStudent()
        {
            var arg = JsonSerializer.Serialize(Student);
            var responce = await client.PostAsync($"Students/AddStudent", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async void EditResignationletter()
        {
            var arg = JsonSerializer.Serialize(Resignationletter);
            var responce = await client.PutAsync($"Resignationletters/EditResignationletter", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async void EditStudent()
        {
            var arg = JsonSerializer.Serialize(Student);
            var responce = await client.PutAsync($"Students/EditStudent", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async void DeleteResignationletter()
        {
            var responce = await client.DeleteAsync($"Resignationletters/DeleteResignationletter");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async void DeleteStudent()
        {
            var responce = await client.DeleteAsync($"Students/DeleteStudent");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

    }
}

