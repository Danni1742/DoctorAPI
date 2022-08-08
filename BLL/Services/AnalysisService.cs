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
    public class AnalysisService : GenericService<Analysis>, IAnalysisService
    {
        public AnalysisService(DoctorsContext context) : base(context)
        { 
        }

        public async Task<Analysis> GetByIdWithInclude(int id)
        {
                return await _doctorsContext.Analyses
                .Where(v => v.Id == id)
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .FirstOrDefaultAsync();
            
        }
    }
}
