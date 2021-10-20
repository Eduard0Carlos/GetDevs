using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IUserService _userService;

        public CandidateController(ICandidateService candidateService, IUserService userService)
        {
            _candidateService = candidateService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            var result = await _userService.GetByEmailAsync(email);
            if (result.Success)
                return Ok(result.Value.Candidate);

            return NotFound(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _candidateService.DeleteAsync(id);
            
            if (result.Success)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Candidate candidate)
        {
            var result = await _candidateService.InsertAsync(candidate);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(CandidateRegisterModel registerModel)
        {
            var candidate = registerModel.ConvertToCandidate();
            var user = registerModel.ConvertToUser();

            var candidateInsertResult = await _candidateService.InsertAsync(candidate);

            if (!candidateInsertResult.Success)
                return NotFound();

            user.SetCandidate(candidateInsertResult.Value.Id);
            var userInsertResult = await _userService.InsertAsync(user);

            if (!userInsertResult.Success)
                return NotFound();

            return Ok();
        }
    }
}
