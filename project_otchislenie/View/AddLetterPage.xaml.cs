using System.Diagnostics;
using project_otchislenie.Model;

namespace project_otchislenie.View
{
    public partial class AddLetterPage : ContentPage
    {
        public ResignationLetter ResignationLetter { get; set; }
        public List<string> Reasons { get; set; }
        public Student Student { get; set; }
        public List<Student> Students { get; set; }

        public AddLetterPage()
        {
            InitializeComponent();
            ResignationLetter = new ResignationLetter();
            Reasons = new List<string>(new string[] { "По собственному желанию", "Академическая задолженность" });
            GetStudents();
            BindingContext = this;
        }

        private async void GetStudents()
        {
            //Debug.WriteLine("ыыыы");

            Students = await DB.GetInstance().GetListStudent();
            if (ResignationLetter.StudentId != 0)
            {
                Student = Students.FirstOrDefault(s => s.Id == ResignationLetter.StudentId);
            }
            OnPropertyChanged(nameof(Students));
            OnPropertyChanged(nameof(Student));
        }

        private async void SaveLetter(object sender, EventArgs e)
        {
            if (Student != null)
            {
                ResignationLetter.StudentId = Student.Id;
            }
            await DB.GetInstance().AddResignationLetter(ResignationLetter);
            OnPropertyChanged(nameof(ResignationLetter));
            await Navigation.PopAsync();
        }
    }
}

