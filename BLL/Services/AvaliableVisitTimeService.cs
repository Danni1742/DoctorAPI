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
    public class AvaliableVisitTimeService : GenericService<AvaliableVisitTime>, IAvaliableVisitTimeService
    {
        public AvaliableVisitTimeService(DoctorsContext context) : base(context)
        { 
        }

        public async Task<AvaliableVisitTime> GetByIdWithInclude(int id)
        {
            var avts = await _doctorsContext.AvaliableVisitTimes.ToListAsync<AvaliableVisitTime>();
            return await _doctorsContext.AvaliableVisitTimes
                .Where(a => a.Id == id)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync();
        }
    }
}
