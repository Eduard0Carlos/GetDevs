using Domain.Entities;
using Domain.Enums;
using Shared.Útils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRankingML.Utils
{
    public static class ResumeExtension
    {
        public static AIResume ConvertToAIResume(this Resume resume, Skill skillRequired, Language languageRequired, Degree degreeRequired, int announcementId, int candidateId)
        {
            var aiResume = new AIResume();

            aiResume.Skills = resume.Skills.EvaluateEnum(skillRequired);
            aiResume.Idioms = resume.Languages.EvaluateEnum(languageRequired);
            aiResume.Educations = resume.Degrees.EvaluateEnum(degreeRequired);

            aiResume.Id = (uint)candidateId;
            aiResume.GroupId = (uint)announcementId;

            var experienceTime = 0;
            resume.BusinessBonds.ToList().ForEach(item => experienceTime += item.GetTimeExperience());
            aiResume.BusinessBonds = experienceTime / resume.BusinessBonds.Count;

            return aiResume;
        }
    }
}
