using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.Interfaces
{
    public interface IAvaliableVisitTimeService : IGenericService<AvaliableVisitTime>
    {
        Task<AvaliableVisitTime> GetByIdWithInclude(int id);
    }
}
