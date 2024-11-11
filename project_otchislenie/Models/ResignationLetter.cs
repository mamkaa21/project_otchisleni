using project_otchislenie.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie.Models
{
    public class Resignationletter : BaseVM
    {
        public int Id { get; set; }

        public string? Reason { get; set; }

        public DateTime? Date { get; set; } = DateTime.Now;

        public int? IdStudent { get; set; }

        public virtual Student? IdStudentNavigation { get; set; }
        [NotMapped]
        public Student Student { get; private set; }

        public override string ToString()
        {

            return $"{Reason}, {Date}, {Student?.Lastname}";
        }

        public async void SetStudent()
        {
            DB.GetInstance().GetStudentById();
            Signal(nameof(Student));
        }
    }
}
