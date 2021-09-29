using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Announcement : EntityBase
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Skill SkillRequired { get; protected set; }
        public ICollection<Idiom> IdiomsRequired { get; protected set; }
        public ICollection<Education> EducationsRequired { get; protected set; }
        public DateTime AnnouncementDate { get; protected set; }
        public DateTime ExpiredDate { get; protected set; }
        public Company Company { get; protected set; }
        public int CompanyId { get; protected set; }
        public ICollection<Person> People { get; protected set; }
    }
}
