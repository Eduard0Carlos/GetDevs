using Domain.Entities;
using Shared.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : EntityBase
    {
        Task<Result> InsertAsync(TEntity entity);
        Task<Result> InsertRangeAsync(IEnumerable<TEntity> entities);
        Task<Result> UpdateAsync(TEntity entity);
        Task<Result> DeleteAsync(TEntity entity);
        Task<Result> DeleteAsync(int id);
        Task<SingleResult<TEntity>> GetByIdAsync(int id);
        Task<DataResult<TEntity>> GetAllAsync();
    }
}
