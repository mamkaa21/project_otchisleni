using project_otchislenie.Views;
namespace project_otchislenie
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Resignationletter", typeof(EditLetterPage));
            Routing.RegisterRoute("Student", typeof(EditStudentPage));
            Routing.RegisterRoute("RegistrationPage", typeof(RegistrationPage));
            Routing.RegisterRoute("StudentPage", typeof(StudentPage));
        }

        
    }
}
