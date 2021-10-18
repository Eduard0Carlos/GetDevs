using AnnotationValidator.Attribute;
using AnnotationValidator.Attributes;
using AnnotationValidator.Interface;
using Domain.Entities;

namespace Infrastructure.ValidationModel
{
    public class UserValidationModel : IEntityValidationModel<User>
    {
        [DisplayName("Senha"), Validation(HasHash = true)]
        public string Password { get; protected set; }
    }
}
