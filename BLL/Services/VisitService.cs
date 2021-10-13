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
    public class VisitService : GenericService<Visit>, IVisitService
    {
        public VisitService(DoctorsContext context) : base(context)
        { 
        }
    }
}
