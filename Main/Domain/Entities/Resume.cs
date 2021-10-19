using Domain.Enums;
using Shared.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Resume : EntityBase    
    {
        public Candidate Candidate { get; set; }
        public int CandidateId { get; protected set; }
        public float? Score { get; protected set; }
        public Skill Skills { get; protected set; }
        public Degree Degrees { get; protected set; }
        public ICollection<Education> Educations { get; protected set; }
        public Language Languages { get; protected set; }
        public ICollection<BusinessBond> BusinessBonds { get; protected set; }

        protected Resume() { }

        public Resume(Skill skills, Degree degrees, Language languages, int candidateId )
        {
            Skills = skills;
            Degrees = degrees;
            Languages = languages;
            CandidateId = candidateId;
        }

        public Resume(int candidateId, Skill skills, Degree degrees, Language languages, ICollection<Education> educations, ICollection<BusinessBond> businessBonds)
        {
            CandidateId = candidateId;
            Skills = skills;
            Degrees = degrees;
            Educations = educations;
            Languages = languages;
            BusinessBonds = businessBonds;
        }

        public Resume SetScore(float score)
        {
            this.Score = score;
            return this;
        }
    }

    public static class ResumeExtension
    {
        public static ResumeAI ConvertToResumeAI(this Resume resume, Announcement announcement)
        {
            var resumeAi = new ResumeAI();

            resumeAi.Skills = resume.Skills.EvaluateEnum(announcement.SkillRequired);
            resumeAi.Idioms = resume.Languages.EvaluateEnum(announcement.LanguagesRequired);
            resumeAi.Educations = resume.Degrees.EvaluateEnum(announcement.DegreesRequired);

            resumeAi.Id = (uint)resume.Candidate.Id;
            resumeAi.GroupId = (uint)announcement.Id;

            var experienceTime = 0;
            resume.BusinessBonds.ToList().ForEach(item => experienceTime += item.GetTimeExperience());
            resumeAi.BusinessBonds = experienceTime / resume.BusinessBonds.Count;

            return resumeAi;
        }
    }
}
