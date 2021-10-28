using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("job/register")]
        public async Task<IActionResult> Post(RegisterInAnnouncementModel model)
        {
            var userResult = await this._userService.GetByEmailAsync(model.Email);
            var result = await this._candidateService.RegisterInAnnouncement(userResult.Value.Candidate, model.AnnouncementId);
            if (result.Success)
                return Ok();

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email, int id)
        {
            if (email != null)
            {
                var result = await _userService.GetByEmailAsync(email);
                if (result.Success)
                    return Ok(result.Value.Candidate);
            }
            else
                return await this.GetDevs(id);

            return NotFound();
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
        public async Task<IActionResult> Put(CandidateRegisterModel registerModel)
        {
            var user = await _userService.GetByEmailAsync(registerModel.Email);
            if (!user.Success)
                return NotFound();

            user.Value.Candidate.SetName(registerModel.Name);
            user.Value.Candidate.SetPhoneNumber(registerModel.PhoneNumber);
            user.Value.Candidate.SetId(user.Value.CandidateId.Value);

            var result = await _candidateService.UpdateAsync(user.Value.Candidate);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        private async Task<IActionResult> GetDevs(int id)
        {
            var result = await _candidateService.GetDevsAsync(id);
            if (result.Success)
                return Ok(result.Data);

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
