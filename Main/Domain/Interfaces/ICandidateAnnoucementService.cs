using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateAnnoucementService : IGenericService<CandidateAnnoucement>
    {
        Task<Result> FindDevs(Announcement announcement);
        Task<DataResult<Candidate>> GetDevs(Announcement announcement);
    }
}
