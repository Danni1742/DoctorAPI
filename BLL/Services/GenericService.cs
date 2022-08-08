using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task Add(TEntity entity)
        {
            await _dbset.AddAsync(entity);
            await _doctorsContext.SaveChangesAsync();
        }

        public async  Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            _doctorsContext.Entry(entity).State = EntityState.Modified;
            await _doctorsContext.SaveChangesAsync(); ;
        }
        public async Task RemoveById(int id)
        {
            var entity = await _dbset.FindAsync(id);
            _dbset.Remove(entity);
            await _doctorsContext.SaveChangesAsync(); ;
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression <Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbset.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

    }
}
