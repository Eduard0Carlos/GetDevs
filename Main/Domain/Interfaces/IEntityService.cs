using Shared.Results;

namespace Domain.Interfaces
{
    public interface IEntityService<TEntity>
    {
        Result Insert(TEntity entity);
        Result Update(TEntity entity);  
        Result Delete(int id);
        Result Delete(TEntity entity);
        SingleResult<TEntity> GetById(int id);
        DataResult<TEntity> GetAll();
    }
}
