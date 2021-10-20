using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcInterface.Models
{
    public class ResumeEditViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string InstitutionName { get; set; }
        public string Degree { get; set; }
        public DateTime InstitutionStart { get; set; }
        public DateTime InstitutionEnd { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public DateTime CompanyStart { get; set; }
        public DateTime CompanyEnd { get; set; }
        public string[] Skills { get; set; }
        public string[] Idioms { get; set; }

        public CandidateViewModel ConvertToCandidateViewModel(string email)
        {
            return new CandidateViewModel()
            {
                Email = email,
                Name = this.Name,
                PhoneNumber = this.PhoneNumber
            };
        }

        public ResumeViewModel ConvertToResumeViewModel(string email)
        {
            return new ResumeViewModel()
            {
                Educations = new List<EducationViewModel>()
                {
                    new EducationViewModel()
                    {
                        InstitutionName = this.InstitutionName,
                        Degree = this.Degree,
                        EndDate = this.InstitutionEnd,
                        StartDate = this.InstitutionStart
                    }
                },
                Skills = this.Skills,
                Languages = this.Idioms,
                Degrees = new[] { this.Degree },
                Email = email,
                BusinessBonds = new List<BusinessBondViewModel>()
                {
                    new BusinessBondViewModel()
                    {
                        CompanyName = this.CompanyName,
                        Role = this.Role,
                        StartDate = this.CompanyStart,
                        EndDate = this.CompanyEnd
                    }
                }
            };
        }
    }
}
