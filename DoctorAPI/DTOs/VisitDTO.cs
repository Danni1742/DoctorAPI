using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAPI.DTOs
{
    public class VisitDTO
    {
        public int Id { get; set; }
        public VisitTypeDTO visitType { get; set; }
        public DateTime dateTime { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }

        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }

        public string Adress { get; set; }
        public string Complaint { get; set; }
        public string Description { get; set; }
        public int DiagnosisId { get; set; }
        public string Recommendation { get; set; }
        public VisitDTO()
        {
            visitType = VisitTypeDTO.primary;
        }


    }
}
