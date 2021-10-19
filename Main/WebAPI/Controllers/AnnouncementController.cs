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
        private readonly IAnnouncementService _annoucementService;
        private readonly IUserService _userService;

        public AnnouncementController(IAnnouncementService annoucementService, IUserService userService)
        { 
            _annoucementService = annoucementService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            var result = await _userService.GetByEmailAsync(email);
            var announcements = new List<Announcement>();   

            if (result.Success)
            {
                result.Value.Candidate.CandidateAnnouncements.ToList().ForEach(a => announcements.Add(a.Announcement));
                return Ok(announcements);
            }

            return NotFound(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _annoucementService.DeleteAsync(id);

            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Announcement announcement)
        {
            var result = await _annoucementService.InsertAsync(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Announcement announcement)
        {
            var result = await _annoucementService.InsertAsync(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
