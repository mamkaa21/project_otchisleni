namespace project_otchislenie
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ResignationLetter", typeof(EditLetterPage));
        }
    }
}
