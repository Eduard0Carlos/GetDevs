using Domain.Entities;
using Domain.Enums;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IResumeService : IGenericService<Resume>
    {
        Task<DataResult<Resume>> GetResumeByRequirementAsync(Skill skill = Skill.None, 
                                                        Language language = Language.Português, 
                                                        Degree degree = Degree.Ensino_Fundamental);
    }
}
