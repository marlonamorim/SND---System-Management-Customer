using Microsoft.EntityFrameworkCore;
using SND.SystemManagementCustomer.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SND.SystemManagementCustomer.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly SystemManagementContext _systemManagementContext;

        public BaseRepository(SystemManagementContext systemManagementContext)
        {
            _systemManagementContext = systemManagementContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _systemManagementContext.Set<TEntity>().Add(entity);
            await _systemManagementContext.SaveChangesAsync();
            _systemManagementContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _systemManagementContext.Entry(entity).State = EntityState.Modified;
            await _systemManagementContext.SaveChangesAsync();
            _systemManagementContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _systemManagementContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _systemManagementContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> SearchAsyc(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                return await _systemManagementContext.Set<TEntity>().Where(predicate).ToListAsync();
            }

            return await _systemManagementContext.Set<TEntity>().ToListAsync();
        }

        public void Remove(int id)
        {
            _systemManagementContext.Set<TEntity>().Remove(_systemManagementContext.Set<TEntity>().Find(id));
        }

        public async Task<int> SaveChanges()
        {
            return await _systemManagementContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> ExecuteStoreProcedure(string storedProcedure, params object[] parameters)
        {
            return _systemManagementContext.Set<TEntity>().FromSqlRaw(storedProcedure, parameters);
        }
    }
}