using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRankingML;

namespace Application.Services
{
    public class CandidateAnnouncementService : GenericService<CandidateAnnouncement>, ICandidateAnnouncementService
    {
        private readonly IResumeService _resumeService;
        public CandidateAnnouncementService(MainContext dbContext, IEntityValidationModel<CandidateAnnouncement> validationModel, IResumeService resumeService)
        : base(dbContext, validationModel)
        {
            this._resumeService = resumeService;
        }

        public async Task<Result> FindDevsAsync(CandidateAnnouncement candidateAnnouncement)
        {
            var announcement = candidateAnnouncement.Announcement;
            var resumeDataResult = await this._resumeService.GetResumeByRequirementAsync(announcement.SkillRequired, announcement.LanguagesRequired, announcement.DegreesRequired);

            foreach (var resume in resumeDataResult.Data)
                await this.InsertAsync(new CandidateAnnouncement(false, resume.Candidate, announcement));

            return ResultFactory.CreateSuccessResult();
        }
    }
}
