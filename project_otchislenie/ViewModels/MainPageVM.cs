using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project_otchislenie.Models;
using project_otchislenie.Views;

namespace project_otchislenie.ViewModels
{
    public class MainPageVM : BaseVM
    {
        public List<Resignationletter> Resignationletters { get; set; }
        public Resignationletter Resignationletter { get; set; }
        public List<Student> Students { get; set; }
        public Student Student { get; set; }
        public CommandVM OpenListStudent { get; }
        public CommandVM DeleteLetter { get; }
        public CommandVM ChangeLetter { get; }

        public MainPageVM()
        {

            OpenListStudent = new CommandVM(async () =>
            {
                await Shell.Current.GoToAsync("StudentPage");
            });
            DeleteLetter = new CommandVM( async () =>
            {
                await DB.GetInstance().DeleteResignationletter(Resignationletter.Id);
                GetData();
                Signal(nameof(Resignationletter));
            });
            ChangeLetter = new CommandVM(async () =>
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"Resignationletter", Resignationletter}
            };
                await Shell.Current.GoToAsync("Resignationletter", dictionary);
            });
        }
        internal void OnAppearing()
        {
            GetData();
        }
        private async void GetData()
        {
            Resignationletters = await DB.GetInstance().GetListResignationletter();
            Signal(nameof(Resignationletters)); 
        }
    }
}
