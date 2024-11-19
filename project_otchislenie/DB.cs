
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
        public User User { get; set; } =  new User();
        private List<User> Users { get; set; }

        private int LastIdStudent = 1;
        private int LastResignationletterId = 1;
        private int LastUserId = 1;


        public DB()
        {
            client.BaseAddress = new Uri("http://10.0.2.2:5246/api/");
        }

        public static DB GetInstance()
        {
            if (instance == null)
                instance = new DB();
            return instance;
        }

        public async Task<User> CheckLoginPassword(User user)
        {
            var arg = JsonSerializer.Serialize(user);
            var responce = await client.PostAsync($"Users/CheckLoginPassword", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибgка", $"{result}", "ок");
                return null;
            }
            else
            {
                var result =  await responce.Content.ReadFromJsonAsync<User>();
                return result;

            }
        }

        public async Task EditUserPassword(User user)
        {
            var arg = JsonSerializer.Serialize(user);
            var responce = await client.PutAsync($"Users/EditUserPassword", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошиб12ка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }

        }



        public async Task<List<User>> GetUsers()
        {
            var responce = await client.GetAsync($"Users/GetUsers");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибlка", $"{result}", "ок");
                return null;
            }
            else
            {
                var users = await responce.Content.ReadFromJsonAsync<List<User>>();
                return users;

            }
        }

        public async Task<List<Resignationletter>> GetListResignationletter()
        {
            var responce = await client.GetAsync($"Resignationletters/GetResignationletters");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Оши1бка", $"{result}", "ок");
                return null;
            }
            else
            {
                var letters = await responce.Content.ReadFromJsonAsync<List<Resignationletter>>();
                foreach (var item in letters)
                {
                    item.SetStudent();
                }
                return letters;
            }
        }

        public async Task<List<Student>> GetListStudent()
        {
            var responce = await client.GetAsync($"Students/GetStudents");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("О2шибка", $"{result}", "ок");
                return null;
            }
            else
            {
                var students = await responce.Content.ReadFromJsonAsync<List<Student>>();
                return students;
            }
        }

        public async Task GetResignationletterById(int id)
        {
            var responce = await client.GetAsync($"Resignationletters/GetResignationletterById/{id}");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ош3ибка", $"{result}", "ок");
                return;
            }
            else
            {
                var letter = await responce.Content.ReadAsStringAsync();
                return;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            var responce = await client.GetAsync($"Students/GetStudentById/{id}");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ош4ибка", $"{result}", "ок");
                return null;
            }
            else
            {
                var student = await responce.Content.ReadFromJsonAsync<Student>();
                return student;
            }
        }

        public async Task AddResignationletter(Resignationletter resignationletter)
        {
            var arg = JsonSerializer.Serialize(resignationletter);
            var responce = await client.PostAsync($"Resignationletters/AddResignationletter", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Оши5бка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async Task<User> AddUser(User user)
        {
            var arg = JsonSerializer.Serialize(user);
            var responce = await client.PostAsync($"Users/AddUser", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошибк6а", $"{result}", "ок");
                return null;
                
            }
            else
            {
                var lastuser = await responce.Content.ReadFromJsonAsync<User>();
                return lastuser;

            }
        }

        public async Task AddStudent(Student student)
        {
            var arg = JsonSerializer.Serialize(student);
            var responce = await client.PostAsync($"Students/AddStudent", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Оши7бка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async Task EditResignationletter(Resignationletter resignationletter)
        {
            var arg = JsonSerializer.Serialize(resignationletter);
            var responce = await client.PutAsync($"Resignationletters/EditResignationletter", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошиб8ка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async Task EditStudent(Student student)
        {
            var arg = JsonSerializer.Serialize(student);
            var responce = await client.PutAsync($"Students/EditStudent", new StringContent(arg, Encoding.UTF8, "application/json"));
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошиб9ка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async Task DeleteResignationletter(int id)
        {
            var responce = await client.DeleteAsync($"Resignationletters/DeleteResignationletter/{id}");
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошиб0ка", $"{result}", "ок");
                return;
            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Успешно", $"{result}", "ок");
            }
        }

        public async Task DeleteStudent(int id)
        {
            var responce = await client.DeleteAsync($"Students/DeleteStudent/{id}");
            if (responce.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошиб11ка", "Такого пользователя не существует", "ок");
                return;
            }
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Ошиб11ка", "Вы не можете удалить студента, пока у него есть заявления", "ок");
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

