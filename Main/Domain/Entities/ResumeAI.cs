using Domain.Enums;
using Shared.Utils;
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
        public static ResumeAI ConvertToResumeAI(this Resume resume, Skill skillRequired, Language languageRequired, Degree degreeRequired, int announcementId, int candidateId)
        {
            var resumeAi = new ResumeAI();

            resumeAi.Skills = resume.Skills.EvaluateEnum(skillRequired);
            resumeAi.Idioms = resume.Languages.EvaluateEnum(languageRequired);
            resumeAi.Educations = resume.Degrees.EvaluateEnum(degreeRequired);

            resumeAi.Id = (uint)candidateId;
            resumeAi.GroupId = (uint)announcementId;

            var experienceTime = 0;
            resume.BusinessBonds.ToList().ForEach(item => experienceTime += item.GetTimeExperience());
            resumeAi.BusinessBonds = experienceTime / resume.BusinessBonds.Count;

            return resumeAi;
        }
    }
}
