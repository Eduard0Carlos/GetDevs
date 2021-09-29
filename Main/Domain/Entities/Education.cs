using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Education : EntityBase
    {
        public int Id { get; protected set; }
        public string InstitutionName { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public Degree Degree { get; protected set; }
        public ICollection<Announcement> Announcements { get; protected set; }
        public ICollection<Person> People { get; protected set; }
        public ICollection<Resume> Resumes { get; protected set; }
    }
}
