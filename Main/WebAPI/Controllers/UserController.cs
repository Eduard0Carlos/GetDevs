using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        public async Task<IActionResult> Put(User user)
        {
            var result = await _userService.UpdateAsync(user);
            if (result.Success)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Post(User user)
        {
            var result = await _userService.Authenticate(user);
            if (!result.Success)
                return NotFound();

            var role = "";
            if (result.Value.CompanyId.HasValue)
                role = "company";
            else
                role = "candidate";

            return Ok(role);
        }
    }
}
