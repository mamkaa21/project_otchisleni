
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie_API.Models
{
    public class ResignationLetter
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int StudentId { get; set; }
        //[NotMapped]
        //public Student Student { get; private set; }
    }
}
