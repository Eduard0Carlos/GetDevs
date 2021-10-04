using AnnotationValidator.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationModel
{
    internal class BusinessBoundValidationModel
    {
        [Validation(IsRequired = true)]
        public DateTime StartDate { get; protected set; }
        [Validation(IsRequired = true, HasNormalize = true, MaxLenght = 100, MinLenght = 5)]
        public string CompanyName { get; protected set; }
        [Validation(IsRequired = true, HasNormalize = true, MaxLenght = 70, MinLenght = 5)]
        public string Role { get; protected set; }
    }
}
