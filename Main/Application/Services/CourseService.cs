using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using AnnotationValidator.Interface;

namespace Application.Services
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(MainContext dbContext, IEntityValidationModel<Course> validationModel) : base(dbContext, validationModel)
        {

        }
    }
}
