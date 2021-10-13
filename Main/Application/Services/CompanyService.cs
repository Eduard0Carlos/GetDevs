using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        public CompanyService(MainContext dbContext) : base(dbContext)
        {

        }
    }
}
