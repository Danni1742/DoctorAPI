using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAPI.DTOs
{
    public class DiseaseDTO
    {
        public int Id { get; set; }
        public List<DiagnosisDTO> Diagnoses { get; set; } = new List<DiagnosisDTO>();

        public string CommonName { get; set; }

        public string Name { get; set; }
        public string MedicalCode { get; set; }
    }
}
