using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private IEntityService<Company> _service;

        public CompanyController(IEntityService<Company> service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _service.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPut]
        public IActionResult Put(Company company)
        {
            var result = _service.Insert(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }


        [HttpPost]
        public IActionResult post(Company company)
        {
            var result = _service.Update(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
