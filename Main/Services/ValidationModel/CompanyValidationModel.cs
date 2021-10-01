using AnnotationValidator.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationModel
{
    internal class CompanyValidationModel
    {
        [Validation(HasNormalize = true, LettersOnly = true, MaxLenght = 70, MinLenght = 3, IsRequired = true)]
        public string Name { get; protected set; }
        [Validation(MaxLenght = 60, MinLenght = 3, IsRequired = true)]
        public string Url { get; protected set; }
        [Validation(LettersOnly = true, MaxLenght = 100, MinLenght = 3, IsRequired = true)]
        public string Sector { get; protected set; }
        [Validation(IsRequired = true)]
        public int CompanySize { get; protected set; }
        [Validation(IsRequired = true, MaxLenght = 600)]
        public string LogoImageUrl { get; protected set; }
        [Validation(IsRequired = true, MaxLenght = 100, MinLenght = 3)]
        public string Slogan { get; protected set; }
    }
}
