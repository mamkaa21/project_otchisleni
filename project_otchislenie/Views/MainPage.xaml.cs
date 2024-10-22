using Microsoft.Maui.Controls;
using project_otchislenie.ViewModels;
using project_otchislenie.Models;
using System.Collections.Specialized;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project_otchislenie.Views
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

       


        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ((MainPageVM)BindingContext).OnAppearing();
        }
       
    }

}
