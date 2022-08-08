using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAPI.DTOs
{
    public class DiagnosisDTO
    {
        public int Id { get; set; }
        public int DisaeseId { get; set; }
        public DiseaseDTO Disease { get; set; }
        public string DiagnosisDescription { get; set; }
    }
}
