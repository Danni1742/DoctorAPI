using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAPI.DTOs
{
    public class AnalysisDTO
    {
        public int Id { get; set; }
        public DateTime AnalysisDateTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Name { get; set; }
        public byte[] FileStream { get; set; }
        public string Result { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }


    }
}
