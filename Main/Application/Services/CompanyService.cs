using Infrastructure;
using Domain.Entities;
using Domain.Interfaces;
using AnnotationValidator.Interface;
using System.Threading.Tasks;
using Shared.Results;
using Shared.Factory;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        public CompanyService(MainContext dbContext, IEntityValidationModel<Company> validationModel) : base(dbContext, validationModel)
        {

        }

        public async Task<SingleResult<Company>> GetByCompanyNameAsync(string companyName)
        {
            return ResultFactory.CreateSuccessSingleResult(
                await this._dbContext.Set<Company>()
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(c => c.Name == companyName)
                                     );
        }
    }
}
