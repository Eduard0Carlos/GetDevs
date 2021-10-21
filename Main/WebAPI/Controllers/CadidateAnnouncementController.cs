﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadidateAnnouncementController : ControllerBase
    {
        private readonly ICandidateAnnouncementService _service;

        public CadidateAnnouncementController(ICandidateAnnouncementService service)
        {
            this._service = service;
        }

        [HttpGet("findevs")]
        public async Task<IActionResult> Post(int announcementId)
        {
            var result = await _service.FindDevsAsync(announcementId);

            if (result.Success)
            {
                return Ok();
            }

            return NotFound(result);
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
        public async Task<IActionResult> Put(CandidateAnnouncement businessBond)
        {
            var result = await _service.InsertAsync(businessBond);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CandidateAnnouncement businessBond)
        {
            var result = await _service.InsertAsync(businessBond);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
