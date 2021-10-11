using AnnotationValidator;
using DataAccessObject;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Utils;
using Services.ValidationModel;
using Shared.Results;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class CandidateService : BaseValidator<Candidate>, IEntityService<Candidate>, IUserService
    {
        public CandidateService()
        {
            this.ValidationModel = typeof(CandidateValidationModel);
        }

        public Result Insert(Candidate entity)
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
                    db.Candidates.Add(entity);
                    db.SaveChanges();
                }
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
           
        }

        public DataResult<Candidate> GetAll()
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessDataResult(db.Candidates.ToList());
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.CreateSuccessDataResult<Candidate>();
            }  
        }

        public Result Update(Candidate entity)
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
                    db.Candidates.Update(entity);
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
                    db.Candidates.Remove(db.Candidates.Find(id));
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public Result Delete(Candidate entity)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.Candidates.Remove(entity);
                    db.SaveChanges();
                    return ResultFactory.CreateSuccessResult();
                }
            }
            catch (Exception ex)
            {
                return Error.asdfg(ex);
            }
        }

        public SingleResult<Candidate> GetById(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessSingleResult(db.Candidates.Find(id));
                }
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureSingleResult<Candidate>();
            }
        }

        public async Task<AuthenticateResult> Authenticate(AuthenticateRequest model)
        {
            AuthenticateResult authenticateResult= new AuthenticateResult();

            try
            {
                using (ErpDbContext db = new ErpDbContext())
                {
                    User user = await db.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                    // AuthenticateResponse authenticaResponse = new AuthenticateResponse();
                    if (user == null)
                    {
                        return null;
                    }
                    authenticateResult.FullName = user.Email;

                    authenticateResult.Email = user.Email;
                    authenticateResult.Id = user.Id;

                    if (user.CompanyId.HasValue)
                    {
                        authenticateResult.IsCompany = true;
                    }
                    else
                    {
                        authenticateResult.IsCandidate = true;
                    }
                    if (user == null) return null;
                    
                    return  authenticateResult;
                }
            }
            catch (Exception ex)
            {
                return authenticateResult = null;
            }
        }   
    }
}
