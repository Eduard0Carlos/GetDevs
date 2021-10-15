﻿using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly ICandidateService _candidateService;
        private readonly IResumeService _resumeService;
        private readonly ICompanyService _companyService;
        private readonly ICandidateAnnouncementService _candidateAnnouncementService;
        private readonly IBusinessBondService _businessBondService;
        private readonly ICourseService _courseService;
        private readonly IEducationService _educationService;

        public CandidateController(IEducationService educationService, ICourseService courseService, IBusinessBondService businessBondService, IAnnouncementService service, ICandidateService candidateService, IResumeService resumeService, ICompanyService companyService, ICandidateAnnouncementService candidateAnnouncementService)
        {
            _educationService = educationService;
            _courseService = courseService;
            _businessBondService = businessBondService;
            _service = service;
            _candidateService = candidateService;
            _resumeService = resumeService;
            _companyService = companyService;
            _candidateAnnouncementService = candidateAnnouncementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            //var result1 = await _candidateService.InsertAsync(new Candidate("Carlos", "11874089990", "89046070", "47991029894", new DateTime(2005, 03, 11), "carloseduardo.blu@outlook.com", "123456"));
            //var result2 = await _resumeService.InsertAsync(new Resume(Skill.CSharp | Skill.Java, Degree.Ensino_Fundamental, Language.Inglês | Language.Português, result1.Value.Id));
            //var result3 = await _companyService.InsertAsync(new Company("Teste", "teste.com", "Desenvolvedor", "63101633000106", 20, "testelogo.com", "testeslogan"));
            //var result4 = await _service.InsertAsync(new Announcement("Anuncio de java", "Vaga para java", Skill.CSharp | Skill.Java, Language.Inglês, Degree.Ensino_Fundamental, 3, DateTime.Now, new DateTime(2022, 03, 11), result3.Value.Id));
            //var result5 = await _candidateAnnouncementService.InsertAsync(new CandidateAnnouncement(false, result1.Value, result4.Value));
            //var result9 = await _businessBondService.InsertAsync(new BusinessBond(new System.DateTime(2000, 03, 11), new System.DateTime(2011, 03, 11), "Senior", "Desenvolvedor", new List<Resume>() { result2.Value }));
            //var result7 = await _candidateAnnouncementService.UpdateAsync(result6.Value);

            var result1 = await _candidateService.GetByIdAsync(1);
            var result2 = await _resumeService.GetByIdAsync(1);
            var result3 = await _businessBondService.GetByIdAsync(1);
            var result4 = await _companyService.GetByIdAsync(1);
            var result5 = await _service.GetByIdAsync(1);
            var resumes = await _resumeService.GetAllAsync();
            var course = new Course("C#", "Proway", new DateTime(2021, 04, 11), new DateTime(2021, 11, 03), Degree.Doutorado, resumes.Data);
            var result6 = await _courseService.GetByIdAsync(1);
            var result7 = await _educationService.GetByIdAsync(1);
            var result8 = await _candidateAnnouncementService.FindAsync(result1.Value.Id, result5.Value.Id);
            var result9 = await _candidateAnnouncementService.FindAsync(result1.Value.Id, result4.Value.Id);
            var result10 = await _candidateService.GetDevsAsync(result5.Value);

            return Ok(result4);
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
        public async Task<IActionResult> Put(Candidate candidate)
        {
            var result = await _service.InsertAsync(candidate);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Candidate candidate)
        {
            var result = await _service.InsertAsync(candidate);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
