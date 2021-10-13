using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Gender {male, female }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public Gender gender { get; set; }


        public int Age()
        {
            var now = DateTime.Now;
            return now.Year - BirthDate.Year;
        }
    }
}
