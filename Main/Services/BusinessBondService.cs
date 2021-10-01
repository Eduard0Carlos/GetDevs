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
    public class BusinessBondService : BaseValidator<BusinessBond>, IEntityService<BusinessBond>
    {
        public Result Delete(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.BusinessBonds.Remove(db.BusinessBonds.Find(id));
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public Result Delete(BusinessBond entity)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.BusinessBonds.Remove(entity);
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public DataResult<BusinessBond> GetAll()
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessDataResult(db.BusinessBonds.ToList());
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.CreateSuccessDataResult<BusinessBond>();
            }
        }

        public SingleResult<BusinessBond> GetById(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessSingleResult(db.BusinessBonds.Find(id));
                }
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<BusinessBond>();
            }
        }

        public Result Insert(BusinessBond entity)
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
                    db.BusinessBonds.Add(entity);
                    db.SaveChanges();
                }
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureResult();
            }
        }

        public Result Update(BusinessBond entity)
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
                    db.BusinessBonds.Update(entity);
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
