using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private IEntityService<Announcement> _service;

        public AnnouncementController(IEntityService<Announcement> service)
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
        public IActionResult Put(Announcement announcement)
        {
            var result = _service.Insert(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public IActionResult Post(Announcement announcement)
        {
            var result = _service.Insert(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
