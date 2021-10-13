using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using AnnotationValidator.Interface;

namespace Application.Services
{
    public class AnnouncementService : GenericService<Announcement>, IAnnouncementService
    {
        public AnnouncementService(MainContext dbContext, IEntityValidationModel<Announcement> validationModel) : base(dbContext, validationModel)
        {

        }
    }
}
