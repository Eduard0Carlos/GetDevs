using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAnnouncementService : IGenericService<Announcement>
    {
        Task<DataResult<Announcement>> GetCompanyAnnouncement(string email);
        Task<DataResult<CandidateAnnouncement>> GetCandidateAnnouncement(string email);
    }
}
