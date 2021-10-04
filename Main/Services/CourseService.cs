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
    public class CourseService : BaseValidator<Course>, IEntityService<Course>
    {
        public CourseService()
        {
            this.ValidationModel = typeof(CourseValidationModel);
        }

        public Result Delete(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Courses.Remove(db.Courses.Find(id));
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public Result Delete(Course entity)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Courses.Remove(entity);
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public DataResult<Course> GetAll()
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessDataResult(db.Courses.ToList());
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.CreateSuccessDataResult<Course>();
            }
        }

        public SingleResult<Course> GetById(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessSingleResult(db.Courses.Find(id));
                }
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Course>();
            }
        }

        public Result Insert(Course entity)
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
                    db.Courses.Add(entity);
                    db.SaveChanges();
                }
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureResult();
            }
        }

        public Result Update(Course entity)
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
                    db.Courses.Update(entity);
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
