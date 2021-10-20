using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IUserService _userService;

        public AnnouncementController(IAnnouncementService annoucementService, IUserService userService)
        { 
            _announcementService = annoucementService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            var result = await _announcementService.GetCompanyAnnouncement(email);
            var announcement = new List<Announcement>();
            
            if (result.Success)
            {
                if (result.Value.Candidate != null)
                    result.Value.Candidate.CandidateAnnouncements.ToList().ForEach(a => announcements.Add(a.Announcement));
                else
                    announcements = result.Value.Company.Announcements.ToList();

                return Ok(announcements);
            }

            return NotFound(result);
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
            var result = await _announcementService.InsertAsync(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Announcement announcement)
        {
            var result = await _announcementService.InsertAsync(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
