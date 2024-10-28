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
        public List<ResignationLetter> ResignationLetters { get; set; }
        public ResignationLetter ResignationLetter { get; set; }
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
                await DB.GetInstance().DeleteResignationLetterById(ResignationLetter);
                GetData();
                Signal(nameof(ResignationLetter));
            });
            ChangeLetter = new CommandVM(async () =>
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"ResignationLetter", ResignationLetter}
            };
                await Shell.Current.GoToAsync("ResignationLetter", dictionary);
            });
        }
        internal void OnAppearing()
        {
            GetData();
        }
        private async void GetData()
        {
            ResignationLetters = await DB.GetInstance().GetListResignationLetter();
            Signal(nameof(ResignationLetters)); 
        }
    }
}
