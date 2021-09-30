using AnnotationValidator.Attributes;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationModel
{
    public class AnnouncementValidationModel
    {
        [Validation(HasNormalize = true, IsRequired = true, MinLenght = 5, MaxLenght = 100)]
        public string Title { get; protected set; }
        [Validation(HasNormalize = true, IsRequired = true, MinLenght = 5, MaxLenght = 1234)]
        public string Description { get; protected set; }
        [Validation(IsRequired = true)]
        public Skill SkillRequired { get; protected set; }
        [Validation(IsRequired = true)]
        public DateTime AnnouncementDate { get; protected set; }
    }
}
