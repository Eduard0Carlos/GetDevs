using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateService : IGenericService<Candidate>
    {
        Task<DataResult<Candidate>> GetDevsAsync(Announcement announcement);
        Task<DataResult<Candidate>> GetRegisteredCandidatesAsync(Announcement announcement);
    }
}
