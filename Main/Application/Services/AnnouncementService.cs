using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class AnnouncementService : GenericService<Announcement>, IAnnouncementService
    {
        public AnnouncementService(MainContext dbContext) : base(dbContext)
        {

        }
    }
}
