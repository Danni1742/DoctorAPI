using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Disease
    {
        public int Id { get; set; }
        public List<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
        public string CommonName { get; set; }

        public string Name { get; set; }
        public string MedicalCode { get; set; }
    }
}
