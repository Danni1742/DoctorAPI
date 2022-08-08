using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAPI.DTOs
{
    public class PatientDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public GenderDTO Gender { get; set; }


       
        public List<VisitDTO> Visits { get; set; } = new List<VisitDTO>();
        public List<AnalysisDTO> Analyses { get; set; } = new List<AnalysisDTO>();
    }
}
