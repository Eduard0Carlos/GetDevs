using Domain.Enums;
using Shared.Extension;
using System.Linq;

namespace Domain.Entities
{
    public class ResumeAI
    {
        public uint Id { get; set; }
        public uint Label { get; set; }
        public uint GroupId { get; set; }
        public float Skills { get; set; }
        public float Educations { get; set; }
        public float Idioms { get; set; }
        public float BusinessBonds { get; set; }
    }

    public static class ResumeAIExtension
    {
        public static ResumeAI ToResumeAI(this Resume resume, Announcement announcement)
        {
            var resumeAi = new ResumeAI();

            resumeAi.Skills = resume.Skills.EvaluateEnum(announcement.SkillRequired);
            resumeAi.Idioms = resume.Languages.EvaluateEnum(announcement.LanguagesRequired);
            resumeAi.Educations = resume.Degrees.EvaluateEnum(announcement.DegreesRequired);

            resumeAi.Id = (uint)resume.CandidateId;
            resumeAi.GroupId = (uint)announcement.Id;

            var experienceTime = 0;
            resume.BusinessBonds.ToList().ForEach(item => experienceTime += item.GetTimeExperience());
            resumeAi.BusinessBonds = experienceTime / resume.BusinessBonds.Count;

            return resumeAi;
        }
    }
}
