using AnnotationValidator.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationModel
{
    internal class PersonValidationModel
    {
        [Validation(IsRequired = true, HasNormalize = true, MaxLenght = 70, MinLenght = 3, LettersOnly = true)]
        public string Name { get; protected set; }
        [Validation(IsRequired = true, FixedLength = 11, IsCPF = true)]
        public string Cpf { get; protected set; }
        //TODO: Implementar um metodo pra validar cep
        [Validation(IsRequired = true, FixedLength = 8)]
        public string Cep { get; protected set; }
        [Validation(IsTelefone = true, IsRequired = true, FixedLength = 13)]
        public string PhoneNumber { get; protected set; }
        [Validation(IsRequired = true)]
        public DateTime BirthDate { get; protected set; }
    }
}
