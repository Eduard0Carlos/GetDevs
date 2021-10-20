using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Factory;
using Shared.Results;
using System.Linq;
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
                           .Include(u => u.Company)
                           .Include(u => u.Candidate)
                           .AsNoTracking()
                           .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userAuthenticated == null)
                return ResultFactory.CreateFailureSingleResult<User>();

            return ResultFactory.CreateSuccessSingleResult(userAuthenticated);
        }

        public async Task<SingleResult<User>> GetByEmailAsync(string email)
        {
            var user = await this._dbContext.Set<User>()
                .Include(u => u.Candidate)
                .Include(u => u.Candidate.CandidateAnnouncements.ToList().Where(c => c.Registered == true))
                .Include(u => u.Company)
                .Include(u => u.Company.Announcements)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return ResultFactory.CreateFailureSingleResult<User>();

            return ResultFactory.CreateSuccessSingleResult(user); 
        }
    }
}
