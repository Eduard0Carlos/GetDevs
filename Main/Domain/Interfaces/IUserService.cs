using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        Task<SingleResult<User>> Authenticate(User user);
        Task<SingleResult<User>> GetByEmailAsync(string email);
    }
}
