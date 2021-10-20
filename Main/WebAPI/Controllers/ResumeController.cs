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
        private readonly ICandidateService _candidateService;

        public ResumeController(ICandidateService candidateService, IResumeService resumeService, IUserService userService)
        {
            _candidateService = candidateService;
            _resumeService = resumeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            var result = await _userService.GetByEmailAsync(email);
            if (result.Success)
            {
                var resume = await _resumeService.GetByIdAsync(result.Value.Candidate.ResumeId.Value);
                return Ok(resume.Value.ConvertToResumeViewModel());
            }

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
            var user = await _userService.GetByEmailAsync(registerModel.Email);

            resume.SetId(user.Value.Candidate.ResumeId.Value);

            var result = await _resumeService.UpdateAsync(resume);

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ResumeRegisterModel registerModel)
        {
            var resume = registerModel.ConvertToResume();
            var user = await this._userService.GetByEmailAsync(registerModel.Email);
            
            resume.SetCandidateId(user.Value.CandidateId.Value);
            var result = await _resumeService.InsertAsync(resume);

            if (result.Success)
            {
                user.Value.Candidate.SetResumeId(result.Value.Id);
                await this._candidateService.UpdateAsync(user.Value.Candidate);
                return Ok(result);
            }

            return NotFound();
        }
    }
}
