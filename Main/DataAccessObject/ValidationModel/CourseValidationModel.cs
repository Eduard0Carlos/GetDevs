using AnnotationValidator.Attributes;
using Domain.Enums;
using System;

namespace Infrastructure.ValidationModel
{
    internal class CourseValidationModel
    {
        [Validation(IsRequired = true, MaxLength = 100, MinLength = 5)]
        public string Name { get; set; }
        [Validation(IsRequired = true, MaxLength = 100, MinLength = 5)]
        public string InstitutionName { get; protected set; }
        [Validation(IsRequired = true)]
        public DateTime StartDate { get; protected set; }
        [Validation(IsRequired = true)]
        public Degree Degree { get; protected set; }
    }
}
