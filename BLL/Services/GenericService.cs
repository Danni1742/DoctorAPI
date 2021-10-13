using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        protected readonly DoctorsContext _doctorsContext;
        protected readonly DbSet<TEntity> _dbset;

        public GenericService(DoctorsContext doctorsContext)
        {
            _doctorsContext = doctorsContext;
            _dbset = doctorsContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
            _doctorsContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Update(TEntity entity)
        {
            _doctorsContext.Entry(entity).State = EntityState.Modified;
            _doctorsContext.SaveChanges(); ;
        }
        public void RemoveById(int id)
        {
            _dbset.Remove(_dbset.Find(id));
            _doctorsContext.SaveChanges(); ;
        }
    }
}
