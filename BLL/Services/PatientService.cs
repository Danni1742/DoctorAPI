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
    public class PatientService : GenericService<Patient>, IPatientService
    {
        public PatientService(DoctorsContext context) : base(context)
        { 
        }

        public async Task AddVisit(int id, Visit visit)
        {
            Patient patient = await GetByIdWithInclude(id);
            patient.Visits.Add(visit);
            await _doctorsContext.SaveChangesAsync();

        }

        public async Task AddAnalysis(int id, Analysis analysis)
        {
            Patient patient = await GetByIdWithInclude(id);
            patient.Analyses.Add(analysis);
            await _doctorsContext.SaveChangesAsync();
        }

        public async Task<Patient> GetByIdWithInclude(int id)
        {
            return await _doctorsContext.Patients
                .Where(v => v.Id == id)
                .Include(v => v.Visits)
                .Include(v => v.Analyses)
                .FirstOrDefaultAsync();
        }

        public async Task RemoveVisit(int id, int visitID)
        {
            Patient patient = await GetByIdWithInclude(id);
            patient.Visits.RemoveAll(a => a.Id == visitID);
            await _doctorsContext.SaveChangesAsync();
        }

        public async Task RemoveAnalysis(int id, int analysisID)
        {
            Patient patient = await GetByIdWithInclude(id);
            patient.Analyses.RemoveAll(a => a.Id == analysisID);
            await _doctorsContext.SaveChangesAsync();
        }

    }
}
