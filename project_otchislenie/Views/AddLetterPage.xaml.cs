using System.Diagnostics;
using project_otchislenie.ViewModels;
using project_otchislenie.Models;

namespace project_otchislenie.Views
{
    public partial class AddLetterPage : ContentPage
    {
        public AddLetterPage()
        {
            InitializeComponent();
            BindingContext = new AddLetterPageVM();
        }
        protected override void OnAppearing()
        {
            ((AddLetterPageVM)BindingContext).OnAppearing();
        }
    }
}

