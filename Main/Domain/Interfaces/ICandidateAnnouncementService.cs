using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICandidateAnnouncementService : IGenericService<CandidateAnnouncement>
    {
        Task<Result> FindDevsAsync(CandidateAnnouncement candidateAnnouncement);
    }
}
