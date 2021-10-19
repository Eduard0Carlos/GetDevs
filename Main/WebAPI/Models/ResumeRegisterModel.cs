using Domain.Entities;
using System;
using Shared.Extension;
using System.Collections.Generic;
using Domain.Enums;

namespace WebAPI.Models
{
    public class ResumeRegisterModel
    {

        public int CandidateId { get; set; }
        public float? Score { get; set; }
        public string[] Skills { get; set; }
        public string[] Degrees { get; set; }
        public ICollection<Education> Educations { get; set; }
        public string[] Languages { get; set; }
        public ICollection<BusinessBond> BusinessBonds { get; set; }

        public Resume ConvertToResume()
        {
            Language language = 0;
            foreach (var item in this.Languages)
                language = language | item.ConvertToEnum<Language>();

            Skill skill = 0;
            foreach (var item in this.Skills)
                skill = skill | item.ConvertToEnum<Skill>();

            Degree degree = 0;
            foreach (var item in this.Degrees)
                degree = degree | item.ConvertToEnum<Degree>();


            return new Resume(
                this.CandidateId,
                skill, 
                degree, 
                language, 
                this.Educations, 
                this.BusinessBonds);
        }

    }
}
