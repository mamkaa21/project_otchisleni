using Microsoft.Maui.Controls;
using System.Collections.Specialized;
using System.ComponentModel;

namespace project_otchislenie
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public List<ResignationLetter> ResignationLetters { get; set; }
        public ResignationLetter ResignationLetter { get; set; }
        public List<Student> Students { get; set; }
        public Student Student { get; set; }


        private DB DB = new DB();

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
        private async void GetStudents()
        {
            Students = await DB.GetListStudent();
            if (ResignationLetter.Student != null)
            {
                Student = Students.FirstOrDefault(s => s.Id == ResignationLetter.StudentId);
            }
            OnPropertyChanged(nameof(Students));
            OnPropertyChanged(nameof(Student));
        }
        private async void GetData()
        {
            ResignationLetters = await DB.GetListResignationLetter();
            OnPropertyChanged(nameof(ResignationLetters));
        }
        private async void OpenListStudent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentPage(DB));
        }

        private async void MakeNewLetter(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLetterPage(DB));
        }

        private async void DeleteLetter(object sender, EventArgs e)
        {
            await DB.DeleteResignationLetterById(ResignationLetter);
            GetData();
        }

        private async void ChangeLetter(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditLetterPage(ResignationLetter, DB));
        }
    }

}
