using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateAnnouncementService : IGenericService<CandidateAnnouncement>
    {
        Task<SingleResult<CandidateAnnouncement>> FindAsync(int candidateId, int announcementId);
        Task<Result> FindDevsAsync(Announcement announcement);
    }
}
