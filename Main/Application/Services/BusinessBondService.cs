using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class BusinessBondService : GenericService<BusinessBond>, IBusinessBondService
    {
        public BusinessBondService(MainContext dbContext) : base(dbContext)
        {

        }
    }
}
