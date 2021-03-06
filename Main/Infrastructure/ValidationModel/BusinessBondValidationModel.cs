using AnnotationValidator.Attributes;
using AnnotationValidator.Interface;
using Domain.Entities;
using System;

namespace Infrastructure.ValidationModel
{
    public class BusinessBondValidationModel : IEntityValidationModel<BusinessBond>
    {
        [Validation(IsRequired = true)]
        public DateTime StartDate { get; protected set; }
        [Validation(IsRequired = true, HasNormalize = true, MaxLength = 100, MinLength = 5)]
        public string CompanyName { get; protected set; }
        [Validation(IsRequired = true, HasNormalize = true, MaxLength = 70, MinLength = 5)]
        public string Role { get; protected set; }
    }
}
