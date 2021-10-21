using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using AnnotationValidator.Interface;
using System.Threading.Tasks;
using Shared.Results;
using Shared.Factory;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class AnnouncementService : GenericService<Announcement>, IAnnouncementService
    {
        protected readonly IUserService _userService;
        public AnnouncementService(IUserService userService, MainContext dbContext, IEntityValidationModel<Announcement> validationModel) : base(dbContext, validationModel)
        {
            this._userService = userService;   
        }

        public async Task<DataResult<CandidateAnnouncement>> GetCandidateAnnouncement(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (!user.Success)
                return ResultFactory.CreateFailureDataResult<CandidateAnnouncement>();

            var announcement = new List<CandidateAnnouncement>();
            if (user.Value.Candidate != null)
                announcement = user.Value.Candidate.CandidateAnnouncements.ToList();

            return ResultFactory.CreateSuccessDataResult(announcement);
        }

        public async Task<DataResult<Announcement>> GetCompanyAnnouncement(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (!user.Success)
                return ResultFactory.CreateFailureDataResult<Announcement>();

            var announcement = new List<Announcement>();
            if (user.Value.Company != null)
                announcement = user.Value.Company.Announcements.ToList();

            return ResultFactory.CreateSuccessDataResult(announcement);
        }
    }
}
