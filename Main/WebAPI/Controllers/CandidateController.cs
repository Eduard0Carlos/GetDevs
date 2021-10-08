using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services;
using Shared.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private IEntityService<Candidate> _service;

        public CandidateController(IEntityService<Candidate> service)
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
        public IActionResult Put(HttpContent content)
        {
            var teste = content.ReadAsStringAsync().Result;
            var candidate = JsonSerializer.Deserialize<Candidate>(teste);
                return Ok();
        }
    }
}
