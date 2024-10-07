using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie
{
    public class ResignationLetter
    {
        public int Id {  get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
    }
}
