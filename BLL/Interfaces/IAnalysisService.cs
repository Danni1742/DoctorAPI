﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.Interfaces
{
    public interface IAnalysisService : IGenericService<Analysis>
    {
        Task<Analysis> GetByIdWithInclude(int id);
    }
}
