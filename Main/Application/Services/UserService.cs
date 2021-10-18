using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Shared.Results;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(MainContext dbContext, IEntityValidationModel<User> validationModel) : base(dbContext, validationModel) 
        {

        }

        public Task<AuthenticateResult> Authenticate(AuthenticateRequest model)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> Register(AuthenticateRequest model)
        {
            throw new System.NotImplementedException();
        }
    }
}
