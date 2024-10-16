namespace project_otchislenie
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ResignationLetter", typeof(EditLetterPage));
            Routing.RegisterRoute("Student", typeof(EditStudentPage));
            Routing.RegisterRoute("RegistrationPage", typeof(RegistrationPage));
        }

        
    }
}
