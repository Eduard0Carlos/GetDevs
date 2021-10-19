﻿using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CandidateAnnouncementService : GenericService<CandidateAnnouncement>, ICandidateAnnouncementService
    {
        protected readonly IResumeService _resumeService;

        public CandidateAnnouncementService(IResumeService resumeService, MainContext dbContext, IEntityValidationModel<CandidateAnnouncement> validationModel)
        : base(dbContext, validationModel)
        {
            this._resumeService = resumeService;
        }

        public async Task<SingleResult<CandidateAnnouncement>> FindAsync(int candidateId, int announcementId)
        {
            return ResultFactory.CreateSuccessSingleResult(
                await this._dbContext.Set<CandidateAnnouncement>()
                                     .FirstOrDefaultAsync(c => c.AnnouncementId == announcementId && c.CandidateId == candidateId));
        }

        public async Task<Result> FindDevsAsync(Announcement announcement)
        {
            var resumeDataResult = await this._resumeService.GetResumeByRequirementAsync(announcement.SkillRequired, announcement.LanguagesRequired, announcement.DegreesRequired);

            foreach (var resume in resumeDataResult.Data)
            {
                try
                {
                    await this.InsertAsync(new CandidateAnnouncement(false, resume.CandidateId, announcement.Id));
                }
                catch (System.Exception)
                {
                    continue;
                }
            }

            return ResultFactory.CreateSuccessResult();
        }
    }
}
