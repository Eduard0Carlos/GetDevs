using AnnotationValidator.Attributes;

namespace Infrastructure.ValidationModel
{
    public class CompanyValidationModel
    {
        [Validation(HasNormalize = true, LettersOnly = true, MaxLength = 70, MinLength = 3, IsRequired = true)]
        public string Name { get; protected set; }
        [Validation(MaxLength = 60, MinLength = 3, IsRequired = true)]
        public string Url { get; protected set; }
        [Validation(LettersOnly = true, MaxLength = 100, MinLength = 3, IsRequired = true)]
        public string Sector { get; protected set; }
        //[Validation("ValidateCnpj", typeof(CommonValidation))]
        public string Cnpj { get; protected set; }  
        [Validation(IsRequired = true)]
        public int CompanySize { get; protected set; }
        [Validation(IsRequired = true, MaxLength = 600)]
        public string LogoImageUrl { get; protected set; }
        [Validation(IsRequired = true, MaxLength = 100, MinLength = 3)]
        public string Slogan { get; protected set; }
    }
}
