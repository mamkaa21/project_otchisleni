using Microsoft.Maui.Controls;
using System.Collections.Specialized;
using System.ComponentModel;

namespace project_otchislenie
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Student> Students { get; set; }

        private DB DB;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OpenListStudent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentPage());
        }

        private async void MakeNewLetter(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLetterPage(DB));
        }

        private async void DeleteLetter(object sender, EventArgs e)
        {

        }

        private async void ChangeLetter(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditLetterPage());
        }
    }

}
