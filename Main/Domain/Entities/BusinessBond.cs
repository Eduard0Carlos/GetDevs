using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BusinessBond : EntityBase
    {
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string CompanyName { get; protected set; }
        public string Role { get; protected set; }
        public ICollection<Resume> Resumes { get; protected set; }

        protected BusinessBond() { }

        public BusinessBond(DateTime startDate, DateTime endDate, string companyName, string role)
        {
            StartDate = startDate;
            EndDate = endDate;
            CompanyName = companyName;
            Role = role;
        }


        public int GetTimeExperience()
        {
            int experienceYears;

            if (this.EndDate != default)
                experienceYears = this.EndDate.Year - this.StartDate.Year;
            else
                experienceYears = DateTime.Now.Year - this.StartDate.Year;

            return experienceYears;
        }
    }
}
