using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        public CourseService(MainContext dbContext) : base(dbContext)
        {

        }
    }
}
