using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BLL.Interfaces;
using Models;
using DAL;

namespace BLL.Services
{
    public class DoctorService : GenericService<Doctor>, IDoctorService
    {
        public DoctorService(DoctorsContext context) : base(context)
        { 
        }
        public Doctor GetByIdWithInclude(int id)
        {
            return _doctorsContext.Doctors
                .Where(d => d.Id == id)
                .Include(d => d.AvaliableVisitTimes)
                .Include(d => d.Visits)
                .FirstOrDefault();
        }
    }
}
