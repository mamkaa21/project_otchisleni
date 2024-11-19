using project_otchislenie.Views;
using project_otchislenie.Models;
namespace project_otchislenie
{
    public partial class AppShell : Shell
    {
        public static User User {  get; set; }
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Resignationletter", typeof(EditLetterPage));
            Routing.RegisterRoute("Student", typeof(EditStudentPage));
            Routing.RegisterRoute("RegistrationPage", typeof(RegistrationPage));
            Routing.RegisterRoute("StudentPage", typeof(StudentPage));
            Routing.RegisterRoute("User", typeof(UserPage));
        }

        
    }
}
