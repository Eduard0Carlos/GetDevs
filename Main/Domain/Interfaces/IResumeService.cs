using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IResumeService : IGenericService<Resume>
    {
        Task<Result> FindDevs(Announcement announcement);
    }
}
