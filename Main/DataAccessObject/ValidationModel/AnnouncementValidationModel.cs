using AnnotationValidator.Attributes;
using Domain.Enums;
using System;

namespace Infrastructure.ValidationModel
{
    public class AnnouncementValidationModel
    {
        [Validation(HasNormalize = true, IsRequired = true, MinLength = 5, MaxLength = 100)]
        public string Title { get; protected set; }
        [Validation(HasNormalize = true, IsRequired = true, MinLength = 5, MaxLength = 1234)]
        public string Description { get; protected set; }
        [Validation(IsRequired = true)]
        public Skill SkillRequired { get; protected set; }
        [Validation(IsRequired = true)]
        public DateTime AnnouncementDate { get; protected set; }
    }
}
