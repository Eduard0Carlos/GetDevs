using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly IAnnouncementService _service;

        public CandidateController(IAnnouncementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result1 = await _service.InsertAsync(new Announcement("Programador Java", @"Procurando por programador java com experiencia :\", Skill.Java | Skill.JavaScript, Language.Inglês, Degree.Ensino_Médio, 15, DateTime.Now, new DateTime(), new Company("Os Quatro Amigos", @"https://www.youtube.com/watch?v=x8jNX1nb_og", "TI", "02.773.206/0001-80", 1600, "https://www.google.com/search?q=logo+imagem+url&rlz", "Programando com eficiencia"), 1));


            return Ok();
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
        public IActionResult Put(HttpContent content)
        {
            var teste = content.ReadAsStringAsync().Result;
            var candidate = JsonSerializer.Deserialize<Candidate>(teste);
                return Ok();
        }
    }
}
