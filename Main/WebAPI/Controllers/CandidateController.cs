﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Put(Candidate candidate)
        {
            var result = _service.Insert(candidate);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public IActionResult Post(Candidate candidate)
        {
            var result = _service.Insert(candidate);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
