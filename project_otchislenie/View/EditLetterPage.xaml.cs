using project_otchislenie.Model;

namespace project_otchislenie.View
{
    [QueryProperty(nameof(ResignationLetter), "ResignationLetter")]
    public partial class EditLetterPage : ContentPage
    {
        private ResignationLetter resignationLetter;

        public ResignationLetter ResignationLetter
        {
            get => resignationLetter;
            set
            {
                resignationLetter = value;
                OnPropertyChanged(nameof(ResignationLetter));
            }
        }

        public List<string> Reasons { get; set; }
        public Student Student { get; set; }
        public List<Student> Students { get; set; }


        public EditLetterPage()
        {
            InitializeComponent();
            Reasons = new List<string> { "По собственному желанию", "Академическая задолженность" };
            GetStudents();
            BindingContext = this;

        }
        private async void GetStudents()
        {
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
            if (ResignationLetter.Id != 0)
            {
                await DB.GetInstance().EditResignationLetter(ResignationLetter);
                OnPropertyChanged(nameof(ResignationLetter));

            }
            await Navigation.PopAsync();
        }
    }

}

