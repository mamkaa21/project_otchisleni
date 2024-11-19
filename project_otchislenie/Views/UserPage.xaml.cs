using System.ComponentModel;
using project_otchislenie.ViewModels;
using project_otchislenie.Models;

namespace project_otchislenie.Views;


public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
        BindingContext = new UserPageVM();
    }
}