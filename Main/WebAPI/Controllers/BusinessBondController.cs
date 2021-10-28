using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessBondController : ControllerBase
    {
        private readonly IBusinessBondService _service;

        public BusinessBondController(IBusinessBondService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BusinessBond businessBond)
        {
            var result = await _service.UpdateAsync(businessBond);
            if (result.Success)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessBond businessBond)
        {
            var result = await _service.InsertAsync(businessBond);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }
    }
}
