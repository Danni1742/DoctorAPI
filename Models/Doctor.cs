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
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public string Bearings { get; set; }

        public string Specialization { get; set; }

        public string VisitPlaceAdress { get; set; }

        //public List<DateTime> AvaliableVisitTime { get; set; } = new List<DateTime>();
        public List<AvaliableVisitTime> AvaliableVisitTimes { get; set; } = new List<AvaliableVisitTime>();

        public List<Visit> Visits { get; set; } = new List<Visit>();

        public int Age()
        {
            if (DateTime.Today.Month > BirthDate.Month) {
                return DateTime.Today.Year - BirthDate.Year;
            }
            else
            {
                if (DateTime.Today.Day < BirthDate.Day)
                {
                    return (DateTime.Today.Year - BirthDate.Year) - 1;
                }
                else
                {
                    return DateTime.Today.Year - BirthDate.Year;
                }
            }
            
        }

    }
}
