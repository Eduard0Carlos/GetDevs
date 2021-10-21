using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateService : IGenericService<Candidate>
    {
        Task<DataResult<Candidate>> GetDevsAsync(int id);
        Task<DataResult<Candidate>> GetRegisteredCandidatesAsync(Announcement announcement);
    }
}
