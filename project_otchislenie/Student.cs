using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Debts { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, возраст - {Age}, долги - {Debts}";
        }
    }
}
