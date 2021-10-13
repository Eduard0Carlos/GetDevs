using AnnotationValidator.Attributes;
using AnnotationValidator.Interface;
using Domain.Entities;
using Infrastructure.Validation;
using System;

namespace Infrastructure.ValidationModel
{
    public class CandidateValidationModel : IEntityValidationModel<Candidate>
    {
        [Validation(IsRequired = true, HasNormalize = true, MaxLength = 70, MinLength = 3, LettersOnly = true)]
        public string Name { get; protected set; }
        [Validation(IsRequired = true, FixedLength = 11, IsCPF = true)]
        public string Cpf { get; protected set; }
        [Validation("ValidateCep", typeof(CommonValidation))]
        public string Cep { get; protected set; }
        [Validation(IsEmail = true, MaxLength = 100)]
        public string Email { get; protected set; }
        [Validation(IsTelefone = true, IsRequired = true, FixedLength = 13)]
        public string PhoneNumber { get; protected set; }
        [Validation(IsRequired = true)]
        public DateTime BirthDate { get; protected set; }
    }
}
