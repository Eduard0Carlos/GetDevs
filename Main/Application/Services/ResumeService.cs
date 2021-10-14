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

        public async Task<DataResult<Resume>> GetResumeByRequirementAsync(Skill skill = Skill.None, Language language = Language.Português, Degree degree = Degree.Ensino_Fundamental)
        {
            return ResultFactory.CreateSuccessDataResult(
                await this._dbContext.Set<Resume>()
                           .AsNoTracking()
                           .Where(r =>
                                  r.Skills.HasFlag(skill) &&
                                  r.Languages.HasFlag(language) &&
                                  r.Degrees.HasFlag(degree))
                           .ToListAsync());
        }
    }
}