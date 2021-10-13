using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using AnnotationValidator.Interface;

namespace Application.Services
{
    public class BusinessBondService : GenericService<BusinessBond>, IBusinessBondService
    {
        public BusinessBondService(MainContext dbContext, IEntityValidationModel<BusinessBond> validationModel) : base(dbContext, validationModel)
        {

        }
    }
}
