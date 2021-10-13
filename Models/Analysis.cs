using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Analysis
    {
        public int Id { get; set; }
        public DateTime AnalysisDateTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Name { get; set; }
        public byte[] FileStream { get; set; }
        public string Result { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }


    }
}
