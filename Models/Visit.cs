using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum VisitType { planed, primary, repeat, urgent}
    public class Visit
    {
        public int Id { get; set; }
        public VisitType visitType { get; set; }
        public DateTime dateTime { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public string Adress { get; set; }
        public string Complaint { get; set; }
        public string Description { get; set; }
        public int DiagnosisId { get; set; }
        public string Recommendation { get; set; }
        public Visit()
        {
            visitType = VisitType.primary;
        }


    }
}
