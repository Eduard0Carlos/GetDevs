using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private ICandidateService _service;

        public CandidateController(ICandidateService service)
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
        public IActionResult Put(HttpContent content)
        {
            var teste = content.ReadAsStringAsync().Result;
            var candidate = JsonSerializer.Deserialize<Candidate>(teste);
                return Ok();
        }
    }
}
