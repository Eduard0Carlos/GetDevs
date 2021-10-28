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
        private readonly ICandidateAnnouncementService _candidateAnnouncementService;

        public CandidateService(MainContext dbContext, ICandidateAnnouncementService candidateAnnouncementService, IEntityValidationModel<Candidate> validationModel) : base(dbContext, validationModel)
        {
            this._candidateAnnouncementService = candidateAnnouncementService;
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

            candidatesRegistered.Data.ForEach(c => c.Resume.SetScore(rankingResult.ToList().FirstOrDefault(r => r.Id == c.Id).Score));

            return ResultFactory.CreateSuccessDataResult(candidatesRegistered.Data);
        }

        public async Task<DataResult<Candidate>> GetRegisteredCandidatesAsync(Announcement announcement)
        {
            var registeredCandidates = new List<Candidate>();

            this._dbContext.Set<CandidateAnnouncement>()
                .Include(u => u.Candidate)
                .Include(u => u.Candidate.Resume)
                .Include(u => u.Candidate.Resume.BusinessBonds)
                .Include(u => u.Candidate.Resume.Educations)
                .Where(e => e.Announcement.Id == announcement.Id && e.Registered)
                .ToList()
                .ForEach(e => registeredCandidates.Add(e.Candidate));

            return ResultFactory.CreateSuccessDataResult(registeredCandidates);
        }

        public async Task<Result> RegisterInAnnouncement(Candidate candidate, int announcementId)
        {
            var candidateAnnouncement = await this._candidateAnnouncementService.FindAsync(candidate.Id, announcementId);
            candidateAnnouncement.Value.SetRegistered();

            await this._candidateAnnouncementService.UpdateAsync(candidateAnnouncement.Value);
            return ResultFactory.CreateSuccessResult();
        }
    }
}   
