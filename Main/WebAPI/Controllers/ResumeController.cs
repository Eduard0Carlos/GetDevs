using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeService _resumeService;
        private readonly IUserService _userService;

        public ResumeController(IResumeService resumeService, IUserService userService)
        {
            _resumeService = resumeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _resumeService.GetByIdAsync(id);

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            var result = await _userService.GetByEmailAsync(email);
            if (result.Success)
                return Ok(result.Value.Candidate.Resume);

            return NotFound(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _resumeService.DeleteAsync(id);

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ResumeRegisterModel registerModel)
        {
            var resume = registerModel.ConvertToResume();
            var result = await _resumeService.InsertAsync(resume);
            
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string name)
        {
            //var resume = registerModel.ConvertToResume();
            //var result = await _resumeService.InsertAsync(resume);

            //if (result.Success)
            //return Ok(result);

            //return NotFound(result);

            return NotFound();
        }
    }
}
