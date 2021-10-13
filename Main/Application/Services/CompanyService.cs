using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using AnnotationValidator.Interface;

namespace Application.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        public CompanyService(MainContext dbContext, IEntityValidationModel<Company> validationModel) : base(dbContext, validationModel)
        {

        }
    }
}
