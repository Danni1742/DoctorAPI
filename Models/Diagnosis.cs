using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
        public string DiagnosisDescription { get; set; }
    }
}
