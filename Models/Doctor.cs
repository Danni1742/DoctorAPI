using System;
using System.Collections.Generic;

namespace Models
{
    public class Doctor //: User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public Gender gender { get; set; }

        public string Bearings { get; set; }

        public string Specialization { get; set; }

        public string VisitPlaceAdress { get; set; }

        //public List<DateTime> AvaliableVisitTime { get; set; } = new List<DateTime>();
        public List<AvaliableVisitTime> AvaliableVisitTimes { get; set; } = new List<AvaliableVisitTime>();

        public List<Visit> Visits { get; set; } = new List<Visit>();

        public int Age()
        {
            var now = DateTime.Now;
            return now.Year - BirthDate.Year;
        }

    }
}
