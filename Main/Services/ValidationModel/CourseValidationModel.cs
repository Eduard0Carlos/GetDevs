using AnnotationValidator.Attributes;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationModel
{
    internal class CourseValidationModel
    {
        [Validation(IsRequired = true, MaxLenght = 100, MinLenght = 5)]
        public string Name { get; set; }
        [Validation(IsRequired = true, MaxLenght = 100, MinLenght = 5)]
        public string InstitutionName { get; protected set; }
        [Validation(IsRequired = true)]
        public DateTime StartDate { get; protected set; }
        [Validation(IsRequired = true)]
        public Degree Degree { get; protected set; }
    }
}
