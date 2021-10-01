using AnnotationValidator;
using DataAccessObject;
using Domain.Entities;
using Domain.Interfaces;
using Services.Utils;
using Services.ValidationModel;
using Shared.Results;
using System;
using System.Linq;

namespace Services
{
    public class AnnouncementService : BaseValidator<Announcement>, IEntityService<Announcement>
    {
        public AnnouncementService()
        {
            this.ValidationModel = typeof(AnnouncementValidationModel);
        }

        public Result Delete(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Announcements.Remove(db.Announcements.Find(id));
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public Result Delete(Announcement entity)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Announcements.Remove(entity);
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public DataResult<Announcement> GetAll()
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessDataResult(db.Announcements.ToList());
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.CreateSuccessDataResult<Announcement>();
            }
        }

        public SingleResult<Announcement> GetById(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessSingleResult(db.Announcements.Find(id));
                }
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Announcement>();
            }
        }

        public Result Insert(Announcement entity)
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
                    db.Announcements.Add(entity);
                    db.SaveChanges();
                }
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureResult();
            }
        }

        public Result Update(Announcement entity)
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
                    db.Announcements.Update(entity);
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
