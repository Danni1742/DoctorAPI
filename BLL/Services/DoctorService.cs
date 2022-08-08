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

        public async Task AddVisit(int id, Visit visit)
        {
            Doctor doctor = await GetByIdWithInclude(id);
            doctor.Visits.Add(visit);
            await _doctorsContext.SaveChangesAsync();

        }

        public async Task AddVisitTime(int id, DateTime dateTime)
        {
            Doctor doctor = await GetByIdWithInclude(id);
            doctor.AvaliableVisitTimes.Add(new AvaliableVisitTime(dateTime, id));
            await _doctorsContext.SaveChangesAsync();
        }

        public async Task<Doctor> GetByIdWithInclude(int id)
        {
            return await _doctorsContext.Doctors
                .Where(v => v.Id == id)
                .Include(v => v.Visits)
                .Include(v => v.AvaliableVisitTimes)
                .FirstOrDefaultAsync();
        }

        public async Task RemoveVisit(int id, int visitID)
        {
            Doctor doctor = await GetByIdWithInclude(id);
            doctor.Visits.RemoveAll(a => a.Id == visitID);
            await _doctorsContext.SaveChangesAsync();
        }

        public async Task RemoveVisitTime(int id, DateTime visitTime)
        {
            Doctor doctor = await GetByIdWithInclude(id);
            doctor.AvaliableVisitTimes.RemoveAll(a => a.AvalibleTime == visitTime);
            await _doctorsContext.SaveChangesAsync();
        }
        public IEnumerable<Doctor> GetDoctorsWithVisits()
        {
            IEnumerable<Doctor> doctors = GetWithInclude(x => x.Visits, y => y.AvaliableVisitTimes);
            return GetWithInclude(x => x.Visits.Count > 0, v => v.Visits, y => y.AvaliableVisitTimes);
        }
        

    }
}
