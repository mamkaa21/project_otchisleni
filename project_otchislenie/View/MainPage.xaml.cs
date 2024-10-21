﻿using Microsoft.Maui.Controls;
using project_otchislenie.Model;
using System.Collections.Specialized;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using project_otchislenie.ViewModel;

namespace project_otchislenie.View
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public List<ResignationLetter> ResignationLetters { get; set; }
        public ResignationLetter ResignationLetter { get; set; }
        public List<Student> Students { get; set; }
        public Student Student { get; set; }


        public MainPage()
        {
            GetData();
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            GetData();
        }
        private async void GetData()
        {
            ResignationLetters = await DB.GetInstance().GetListResignationLetter();
            OnPropertyChanged(nameof(ResignationLetters));
        }
        private async void OpenListStudent(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new StudentPage());
        }

        private async void DeleteLetter(object sender, EventArgs e)
        {
            await DB.GetInstance().DeleteResignationLetterById(ResignationLetter);
            GetData();
        }

        private async void ChangeLetter(object sender, EventArgs e)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"ResignationLetter", ResignationLetter}
            };
            await Shell.Current.GoToAsync("ResignationLetter", dictionary);
            //await Navigation.PushAsync(new EditLetterPage(ResignationLetter));
        }
    }

}