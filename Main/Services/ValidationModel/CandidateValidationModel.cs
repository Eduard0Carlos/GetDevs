﻿using AnnotationValidator.Attributes;
using Services.Validation;
using System;

namespace Services.ValidationModel
{
    internal class CandidateValidationModel
    {
        [Validation(IsRequired = true, HasNormalize = true, MaxLenght = 70, MinLenght = 3, LettersOnly = true)]
        public string Name { get; protected set; }
        [Validation(IsRequired = true, FixedLength = 11, IsCPF = true)]
        public string Cpf { get; protected set; }
        [Validation("ValidateCep", typeof(CommonValidation))]
        public string Cep { get; protected set; }
        [Validation(IsEmail = true, MaxLenght = 100)]
        public string Email { get; protected set; }
        [Validation(IsTelefone = true, IsRequired = true, FixedLength = 13)]
        public string PhoneNumber { get; protected set; }
        [Validation(IsRequired = true)]
        public DateTime BirthDate { get; protected set; }
    }
}
