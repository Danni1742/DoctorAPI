using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAPI.DTOs
{
    public class AvtDTO
    {
        public int Id { get; set; }
        public DateTime AvalibleTime { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }

    }
}
