using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        Task<AuthenticateResult> Authenticate(AuthenticateRequest model);
        Task<Result> Register(AuthenticateRequest model);
    }
}
