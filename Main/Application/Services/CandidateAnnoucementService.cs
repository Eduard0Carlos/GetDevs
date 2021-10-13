using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Shared.Factory;
using Shared.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CandidateAnnoucementService : GenericService<CandidateAnnoucement>, ICandidateAnnoucementService
    {
        public CandidateAnnoucementService(MainContext dbContext, IEntityValidationModel<CandidateAnnoucement> validationModel) : base(dbContext, validationModel)
        {

        }

        public async Task<Result> FindDevs(Announcement announcement)
        {
            var resumes = this._dbContext.Set<Resume>()
                .Where(r => r.Skills.HasFlag(announcement.SkillRequired) &&
                r.Languages.HasFlag(announcement.LanguagesRequired) &&
                r.Degrees.HasFlag(announcement.DegreesRequired))
                .ToList();

            if (resumes.Count < announcement.RequiredCandidates)
            {
                resumes.AddRange(this._dbContext.Set<Resume>()
                    .Where(r => r.Skills.HasFlag(announcement.SkillRequired) &&
                (r.Languages.HasFlag(announcement.LanguagesRequired) ||
                r.Degrees.HasFlag(announcement.DegreesRequired))
                ));
            }

            foreach (var item in resumes)
                await this._dbContext.Set<CandidateAnnoucement>().AddAsync(new CandidateAnnoucement(false, item.Candidate, announcement));

            await this._dbContext.SaveChangesAsync();

            return ResultFactory.CreateSuccessResult();
        }

        public Task<DataResult<Candidate>> GetDevs(Announcement announcement)
        {
            throw new System.NotImplementedException();
        }
    }
}
