using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Course : Education
    {
        public string Name { get; protected set; }

        protected Course() { }

        public Course(
            string name, 
            string institutionName, 
            DateTime startDate, 
            DateTime endDate, 
            string degree, 
            ICollection<Resume> resumes
            ) : base(institutionName, startDate, endDate, degree)
        {
            Name = name;
        }
    }
}
