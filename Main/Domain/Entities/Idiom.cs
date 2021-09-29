using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Idiom : EntityBase
    {
        public int Id { get; protected set; }
        public Language Language { get; protected set; }
        public Proficiency ReadProficiency { get; protected set; }
        public Proficiency WriteProficiency { get; protected set; }
        public Proficiency SpeechProficiency { get; protected set; }
        public ICollection<Announcement> Announcements { get; protected set; }
        public ICollection<Person> People { get; protected set; }
        public ICollection<Resume> Resumes { get; protected set; }
    }
}
