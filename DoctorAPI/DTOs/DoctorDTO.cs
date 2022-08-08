using System;
using System.Collections.Generic;

namespace DoctorAPI.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public GenderDTO Gender { get; set; }

        public string Bearings { get; set; }

        public string Specialization { get; set; }

        public string VisitPlaceAdress { get; set; }

        public ICollection<AvtDTO> AvaliableVisitTimes { get; set; } = new List<AvtDTO>();

        public ICollection<VisitDTO> Visits { get; set; } = new List<VisitDTO>();

        public int Age()
        {
            var now = DateTime.Now;
            return now.Year - BirthDate.Year;
        }

    }
}
