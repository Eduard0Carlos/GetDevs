using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Threading.Tasks;
using AnnotationValidator;
using AnnotationValidator.Interface;
using Shared.Extension;

namespace Application.Services
{
    public class GenericService<TEntity> : BaseValidator<TEntity>, IGenericService<TEntity> where TEntity : EntityBase
    {
        protected readonly MainContext _dbContext;

        public GenericService(MainContext dbContext, IEntityValidationModel<TEntity> validationModel)
        {
            this._dbContext = dbContext;
            this.ValidationModel = validationModel.GetType();
        }

        public virtual async Task<Result> DeleteAsync(TEntity entity)
        {
            this._dbContext.Set<TEntity>()
                .Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }

        public virtual async Task<Result> DeleteAsync(int id)
        {
            var entity = await this._dbContext.Set<TEntity>()
                .AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            this._dbContext.Set<TEntity>().Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }

        public virtual async Task<DataResult<TEntity>> GetAllAsync()
        {
            var entities = await this._dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            return ResultFactory.CreateSuccessDataResult(entities);
        }

        public virtual async Task<SingleResult<TEntity>> GetByIdAsync(int id)
        {
            var entity = await this._dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return ResultFactory.CreateSuccessSingleResult(entity);
        }

        public virtual async Task<Result> InsertAsync(TEntity entity)
        {
            var validation = this.Validate(entity);
            if (!validation.IsValid)
                return validation.ToResult();

            await this._dbContext.Set<TEntity>().AddAsync(entity);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }

        public virtual async Task<Result> UpdateAsync(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Update(entity);
            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }
    }
}
