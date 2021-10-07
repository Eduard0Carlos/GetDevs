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
    public class ResumeService : BaseValidator<Resume>, IEntityService<Resume>
    {
        public Result FindDevs(Announcement announcement)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    var resumes = db.Resumes.Where(r => r.Skills.HasFlag(announcement.SkillRequired) && r.Languages.HasFlag(announcement.LanguagesRequired) && r.Degrees.HasFlag(announcement.degreesRequired)).ToList();
                    if (resumes.Count < announcement.Count * 2)
                    {
                        resumes.AddRange(db.Resumes.Where(r =>
                        r.Skills.HasFlag(announcement.SkillRequired) &&
                        (r.Languages.HasFlag(announcement.LanguagesRequired) ||
                        r.Degrees.HasFlag(announcement.degreesRequired))
                        ));
                    }

                    foreach (var item in resumes)
                    {
                        db.Announcements.Find(announcement.Id).People.Add(db.People.Find(item.PersonId));
                    }

                    db.SaveChanges();

                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {

                return Error.asdfg(ex);
            }

        }

        public Result Delete(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Resumes.Remove(db.Resumes.Find(id));
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public Result Delete(Resume entity)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Resumes.Remove(entity);
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public DataResult<Resume> GetAll()
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessDataResult(db.Resumes.ToList());
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.CreateSuccessDataResult<Resume>();
            }
        }

        public SingleResult<Resume> GetById(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessSingleResult(db.Resumes.Find(id));
                }
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Resume>();
            }
        }

        public Result Insert(Resume entity)
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
                    db.Resumes.Add(entity);
                    db.SaveChanges();
                }
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureResult();
            }
        }

        public Result Update(Resume entity)
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
                    db.Resumes.Update(entity);
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
