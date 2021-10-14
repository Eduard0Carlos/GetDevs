using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateAnnouncementService : IGenericService<CandidateAnnouncement>
    {
        Task<Result> FindDevs(CandidateAnnouncement candidateAnnouncement);
        Task<DataResult<CandidateAnnouncement>> GetDevs(Announcement announcement);
    }
}
