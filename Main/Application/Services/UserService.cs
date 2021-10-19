using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(MainContext dbContext, IEntityValidationModel<User> validationModel) : base(dbContext, validationModel) 
        {

        }

        public async Task<SingleResult<User>> Authenticate(User user)
        {
            var result = this.Validate(user);

            if (!result.IsValid)
                return ResultFactory.CreateFailureSingleResult<User>();

            var userAuthenticated = await this._dbContext.Set<User>()
                           .AsNoTracking()
                           .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userAuthenticated == null)
                return ResultFactory.CreateFailureSingleResult<User>();

            if (userAuthenticated.Password != user.Password)
                return ResultFactory.CreateFailureSingleResult<User>();

            return ResultFactory.CreateSuccessSingleResult(user);
        }

        public async Task<SingleResult<User>> Register(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
