using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AvaliableVisitTime
    {
        public int Id { get; set; }
        public DateTime AvalibleTime { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
