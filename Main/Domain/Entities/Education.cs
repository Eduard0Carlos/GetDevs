using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Education : EntityBase
    {

        public string InstitutionName { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string Degree { get; protected set; }
        public ICollection<Resume> Resumes { get; protected set; }

        protected Education() { }

        public Education(string institutionName, DateTime startDate, DateTime endDate, string degree)
        {
            InstitutionName = institutionName;
            StartDate = startDate;
            EndDate = endDate;
            Degree = degree;
        }
    }
}
