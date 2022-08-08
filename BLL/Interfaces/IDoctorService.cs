using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace BLL.Interfaces
{
    public interface IDoctorService : IGenericService<Doctor>
    {
        Task<Doctor> GetByIdWithInclude(int id);
        Task AddVisitTime(int id, DateTime dateTime);
        Task RemoveVisitTime(int id, DateTime visitTime);
        Task AddVisit(int id, Visit visit);
        Task RemoveVisit(int id, int visitId);
        public IEnumerable<Doctor> GetDoctorsWithVisits();
    }
}
