using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Patient //: User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public Gender gender { get; set; }


       
        public List<Visit> Visits { get; set; } = new List<Visit>();
//        public List<Visit> FutureVisits { get; set; } = new List<Visit>();
        public List<Analysis> Analyses { get; set; } = new List<Analysis>();
        //       public List<Analysis> FutureAnalyses { get; set; } = new List<Analysis>();


        public int Age()
        {
            var now = DateTime.Now;
            return now.Year - BirthDate.Year;
        }
    }
}
