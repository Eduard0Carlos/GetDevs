using AnnotationValidator.Attributes;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ValidationModel
{
    internal class IdiomValidationModel
    {
        [Validation(IsRequired = true)]
        public Language Language { get; protected set; }
        [Validation(IsRequired = true)]
        public Proficiency ReadProficiency { get; protected set; }
        [Validation(IsRequired = true)]
        public Proficiency WriteProficiency { get; protected set; }
        [Validation(IsRequired = true)]
        public Proficiency SpeechProficiency { get; protected set; }
    }
}
