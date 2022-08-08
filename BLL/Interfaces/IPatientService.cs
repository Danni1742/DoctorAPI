using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace BLL.Interfaces
{
    public interface IPatientService : IGenericService<Patient>
    {
        Task<Patient> GetByIdWithInclude(int id);
        Task AddVisit(int id, Visit visit);
        Task RemoveVisit(int id, int visitId);
        Task AddAnalysis(int id, Analysis analysis);
        Task RemoveAnalysis(int id, int analysisID);

    }
}
