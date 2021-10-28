using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IUserService _userService;
        private readonly ICandidateAnnouncementService _candidateAnnouncementService;

        public AnnouncementController(ICandidateAnnouncementService candidateAnnouncementService, IAnnouncementService annoucementService, IUserService userService)
        {
            _candidateAnnouncementService = candidateAnnouncementService;
            _announcementService = annoucementService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetByEmailAsync(email);

            if (user.Value.Company != null)
            {
                var result = await _announcementService.GetCompanyAnnouncement(email);
                if (result.Success)
                    return Ok(result.Data);
            }
            else
            {
                var announcementResult = await this._announcementService.GetAllAsync();
                foreach (var announcement in announcementResult.Data)
                {
                    await this._candidateAnnouncementService.FindDevsAsync(announcement.Id);
                }

                var result = await _announcementService.GetCandidateAnnouncement(email);
                if (result.Success)
                {
                    foreach (var item in result.Data)
                    {
                        var an = await _announcementService.GetByIdAsync(item.AnnouncementId);
                        item.SetAnnouncement(an.Value);
                    }
                    var resultList = new List<CandidateAnnouncementViewModel>();
                    result.Data.ForEach(c => resultList.Add(c.ConvertToCandidateAnnouncementViewModel()));
                    return Ok(resultList);
                }
            }

            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _announcementService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Announcement announcement)
        {
            var result = await _announcementService.UpdateAsync(announcement);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost("findevs")]
        public async Task<IActionResult> Post(FindDevsModel model)
        {
            await _candidateAnnouncementService.FindDevsAsync(model.Id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnnouncementRegisterViewModel registerModel)
        {
            var user = await _userService.GetByEmailAsync(registerModel.Email);
            var announcement = registerModel.ConvertToAnnouncement();
            announcement.SetCompanyId(user.Value.CompanyId.Value);
            var result = await _announcementService.InsertAsync(announcement);

            if (result.Success)
            {
                await _candidateAnnouncementService.FindDevsAsync(result.Value.Id);
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
