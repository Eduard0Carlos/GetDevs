using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class EducationService : GenericService<Education>, IEducationService
    {
        public EducationService(MainContext dbContext) : base(dbContext)
        {

        }
    }
}
