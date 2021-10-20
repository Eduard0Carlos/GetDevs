using Domain.Entities;
using System;
using Shared.Extension;
using System.Collections.Generic;
using Domain.Enums;

namespace WebAPI.Models
{
    public class ResumeRegisterModel
    {
        public string Email { get; set; }
        public float? Score { get; set; }
        public string[] Skills { get; set; }
        public string[] Degrees { get; set; }
        public ICollection<EducationViewModel> Educations { get; set; }
        public string[] Languages { get; set; }
        public ICollection<BusinessBondViewModel> BusinessBonds { get; set; }

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
                0,
                skill,
                degree,
                language,
                this.Educations.ToEducation(),
                this.BusinessBonds.ToBusinessBond()
                );
        }
    }

    public static class ResumeExtension
    {
        public static ResumeRegisterModel ConvertToResumeViewModel(this Resume resume)
        {
            return new ResumeRegisterModel()
            {
                Skills = resume.Skills.ToString().Split(", "),
                Degrees = resume.Degrees.ToString().Split(", "),
                Languages = resume.Languages.ToString().Split(", "),
                BusinessBonds = resume.BusinessBonds.ToBusinessBondViewModel(),
                Educations = resume.Educations.ToEducationViewModel()
            };
        }
    }
}
