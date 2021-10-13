using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Results;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CandidateService : GenericService<Candidate>, ICandidateService
    {
        public CandidateService(MainContext dbContext) : base(dbContext)
        {

        }

        public async Task<AuthenticateResult> Authenticate(AuthenticateRequest model)
        {
            var authenticateResult= new AuthenticateResult();

            try
            {
                using (MainContext db = new MainContext())
                {
                    var user = await db.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                    
                    if (user == null)
                        return null;
                    
                    authenticateResult.FullName = user.Email;

                    authenticateResult.Email = user.Email;
                    authenticateResult.Id = user.Id;

                    if (user.CompanyId.HasValue)
                        authenticateResult.IsCompany = true;
                    else
                        authenticateResult.IsCandidate = true;
                    
                    if (user == null)
                        return null;
                    
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
