using Domain.Entities;
using Shared.Results;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<SingleResult<Company>> GetByCompanyNameAsync(string companyName);
    }
}
