using AnnotationValidator;
using DataAccessObject;
using Domain.Entities;
using Domain.Interfaces;
using Services.Utils;
using Shared.Results;
using System;
using System.Linq;

namespace Services
{
    public class IdiomService : BaseValidator<Idiom>, IEntityService<Idiom>
    {
        public Result Delete(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Idioms.Remove(db.Idioms.Find(id));
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public Result Delete(Idiom entity)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Idioms.Remove(entity);
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public DataResult<Idiom> GetAll()
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessDataResult(db.Idioms.ToList());
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.CreateSuccessDataResult<Idiom>();
            }
        }

        public SingleResult<Idiom> GetById(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessSingleResult(db.Idioms.Find(id));
                }
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Idiom>();
            }
        }

        public Result Insert(Idiom entity)
        {
            var response = this.Validate(entity);
            if (!response.Success)
            {
                return response;
            }

            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Idioms.Add(entity);
                    db.SaveChanges();
                }
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureResult();
            }
        }

        public Result Update(Idiom entity)
        {
            var response = this.Validate(entity);
            if (!response.Success)
            {
                return response;
            }

            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Idioms.Update(entity);
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }
    }
}
