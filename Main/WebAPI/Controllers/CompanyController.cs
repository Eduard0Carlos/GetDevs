using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public CompanyController(ICompanyService companyService, IUserService userService)
        {
            this._userService = userService;
            this._companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email, string companyName)
        {
            if (!string.IsNullOrWhiteSpace(companyName))
                return await this.GetCompanyByName(companyName);
            else
                return await this.GetByEmail(email);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyService.DeleteAsync(id);

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        public async Task<IActionResult> Put(Company company)
        {
            var result = await _companyService.UpdateAsync(company);
            if (result.Success)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(CompanyRegisterModel registerModel)
        {
            var company = registerModel.ConvertToCompany();
            var user = registerModel.ConvertToUser();
            var companyInsertResult = await _companyService.InsertAsync(company);

            if (!companyInsertResult.Success)
                return NotFound();

            user.SetCompanyId(companyInsertResult.Value.Id);
            var userInsertResult = await _userService.InsertAsync(user);

            if (!userInsertResult.Success)
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            var result = await _companyService.InsertAsync(company);
            if (result.Success)
                return Ok(result);
            
            return NotFound(result);
        }

        private async Task<IActionResult> GetByEmail(string email)
        {
            var result = await _userService.GetByEmailAsync(email);
            if (result.Success)
                return Ok(result.Value.Company);

            return NotFound();
        }

        private async Task<IActionResult> GetCompanyByName(string companyName)
        {
            var result = await _companyService.GetByCompanyNameAsync(companyName);
            if (result.Success)
                return Ok(result.Value);

            return NotFound();
        }
    }
}
