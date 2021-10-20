using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Results;
using System.Threading.Tasks;
using AnnotationValidator.Interface;
using System.Collections.Generic;
using WebRankingML;
using Shared.Factory;
using System.Linq;

namespace Application.Services
{
    public class CandidateService : GenericService<Candidate>, ICandidateService
    {
        public CandidateService(MainContext dbContext, IEntityValidationModel<Candidate> validationModel) : base(dbContext, validationModel)
        {

        }

        public async Task<AuthenticateResult> Authenticate(AuthenticateRequest model)
        {
            var authenticateResult = new AuthenticateResult();

            var user = await this._dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

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

            return authenticateResult;
        }
        public async Task<DataResult<Candidate>> GetDevsAsync(int announcementId)
        {
            var announcement = await this._dbContext.Set<Announcement>().FindAsync(announcementId);
            var candidatesRegistered = await this.GetRegisteredCandidatesAsync(announcement);
            var resumes = new List<ResumeAI>();

            candidatesRegistered?.Data?.ForEach(c =>
            resumes.Add(c.Resume.ConvertToResumeAI(announcement)));

            var dataView = AIContext.PrepareData(resumes);
            var rankingResult = AIContext.Rank(dataView);

            candidatesRegistered.Data.ForEach(c => c.Resume.SetScore(rankingResult.ToList().FirstOrDefault(r => r.Id == c.Resume.Id).Score));

            return ResultFactory.CreateSuccessDataResult(candidatesRegistered.Data);
        }

        public async Task<DataResult<Candidate>> GetRegisteredCandidatesAsync(Announcement announcement)
        {
            var registeredCandidates = new List<Candidate>();

            this._dbContext.Set<CandidateAnnouncement>()
                .Where(e => e.Announcement == announcement && e.Registered)
                .ToList()
                .ForEach(e => registeredCandidates.Add(e.Candidate));

            return ResultFactory.CreateSuccessDataResult(registeredCandidates);
        }
    }
}   
