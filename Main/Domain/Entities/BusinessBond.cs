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
        public int GetTimeExperience()
        {
            var experienceYears = 0;
            if (this.EndDate != default)
            {
                experienceYears = this.EndDate.Year - this.StartDate.Year;
            }
            else
            {
                experienceYears = DateTime.Now.Year - this.StartDate.Year;
            }
            return experienceYears;
        }
    }
}
