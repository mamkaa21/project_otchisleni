using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public int? Age { get; set; }

        public int? Debts { get; set; }

        public virtual ICollection<Resignationletter> Resignationletters { get; set; } = new List<Resignationletter>();

        public override string ToString()
        {
            return $"{Lastname} {Firstname}, возраст - {Age}, долги - {Debts}";
        }
    }
}
