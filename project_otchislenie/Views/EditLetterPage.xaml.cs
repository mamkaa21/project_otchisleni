using project_otchislenie.ViewModels;
using project_otchislenie.Models;

namespace project_otchislenie.Views
{
    public partial class EditLetterPage : ContentPage
    {
        public EditLetterPage()
        {
            InitializeComponent();
            BindingContext = new EditLetterPageVM();
        }
    }

}

