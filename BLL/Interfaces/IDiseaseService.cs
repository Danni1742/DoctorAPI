using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.Interfaces
{
    public interface IDiseaseService : IGenericService<Disease>
    {
        Task<Disease> GetByIdWithInclude(int id);
        Task AddDiagnosis(int diseaseId, Diagnosis diagnosis);
        Task RemoveDiagnosis(int diseaseId, Diagnosis diagnosis);

    }
}
