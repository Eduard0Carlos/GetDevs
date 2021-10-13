using AnnotationValidator.Interface;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Shared.Factory;
using Shared.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResumeService : GenericService<Resume>, IResumeService
    {
        public ResumeService(MainContext dbContext, IEntityValidationModel<Resume> validationModel) : base(dbContext, validationModel)
        {

        }

        
    }
}