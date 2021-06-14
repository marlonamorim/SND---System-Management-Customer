using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SND.SystemManagementCustomer.Repository.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        void Remove(int id);

        Task<IEnumerable<TEntity>> SearchAsyc(Expression<Func<TEntity, bool>> predicate);
        
        IEnumerable<TEntity> ExecuteStoreProcedure(string storedProcedure, params object[] parameters);
    }
}