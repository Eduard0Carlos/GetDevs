using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResumeService : GenericService<Resume>, IResumeService
    {
        public ResumeService(MainContext dbContext, IEntityValidationModel<Resume> validationModel) : base(dbContext, validationModel)
        {

        }

        public override async Task<SingleResult<Resume>> GetByIdAsync(int id)
        {
            var resume = await this._dbContext.Set<Resume>().Include(r => r.BusinessBonds).Include(r => r.Educations).FirstOrDefaultAsync(e => e.Id == id);
            return ResultFactory.CreateSuccessSingleResult<Resume>(resume);
        }

        public async Task<DataResult<Resume>> GetResumeByRequirementAsync(Skill skill = Skill.None, Language language = Language.Português, Degree degree = Degree.Ensino_Fundamental)
        {
            return ResultFactory.CreateSuccessDataResult(
                await this._dbContext.Set<Resume>()
                           .Where(r =>
                                  r.Skills.HasFlag(skill) &&
                                  r.Languages.HasFlag(language) &&
                                  r.Degrees.HasFlag(degree))
                           .ToListAsync());
        }
    }
}