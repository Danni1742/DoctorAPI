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
    public class DiseaseService : GenericService<Disease>, IDiseaseService
    {
        public DiseaseService(DoctorsContext context) : base(context)
        { 
        }


        public async Task<Disease> GetByIdWithInclude(int id)
        {
            return await _doctorsContext.Diseases
                .Where(v => v.Id == id)
                .Include(v => v.Diagnoses)
                .FirstOrDefaultAsync();
        }

        public async Task AddDiagnosis(int diseaseId, Diagnosis diagnosis)
        {
            Disease disease = await GetByIdWithInclude(diseaseId);
            disease.Diagnoses.Add(diagnosis);
            await _doctorsContext.SaveChangesAsync();
        }

        public async Task RemoveDiagnosis(int diseaseId, Diagnosis diagnosis)
        {

            Disease disease = await GetByIdWithInclude(diseaseId);
            disease.Diagnoses.RemoveAt(disease.Id);
            await _doctorsContext.SaveChangesAsync();
        }

    }
}
