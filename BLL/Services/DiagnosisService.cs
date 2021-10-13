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
    public class DiagnosisService : GenericService<Diagnosis>, IDiagnosisService
    {
        public DiagnosisService(DoctorsContext context) : base(context)
        { 
        }
        public Diagnosis GetByIdWithInclude(int id)
        {
            return _doctorsContext.Diagnoses
                .Where(d => d.Id == id)
                .Include(d => d.diseases)
                .FirstOrDefault();
        }
    }
}
