using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using AnnotationValidator.Interface;

namespace Application.Services
{
    public class EducationService : GenericService<Education>, IEducationService
    {
        public EducationService(MainContext dbContext, IEntityValidationModel<Education> validationModel) : base(dbContext, validationModel)
        {

        }
    }
}
