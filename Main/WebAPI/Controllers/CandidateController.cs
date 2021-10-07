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

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = _service.GetById(int.Parse(id));
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpDelete()]
        public IActionResult Delete(string id)
        {
            var result = _service.Delete(int.Parse(id));
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

            return Enumerable.Empty;
        }
    }
}
