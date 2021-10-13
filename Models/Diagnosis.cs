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
        public List<Disease> diseases { get; set; } = new List<Disease>();
        public string DiagnosisDescription { get; set; }
    }
}
