using System;
using System.Reflection;

namespace AnnotationValidator.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ValidationAttribute : System.Attribute
    {
        private int _maxLength = 100;
        private string _methodName;
        private Type _validationClass;

        public int MinLength { get; set; }
        public bool HasNormalize { get; set; }
        public bool HasHash { get; set; }
        public bool IsRequired { get; set; }
        public bool IsEmail { get; set; }
        public bool IsCPF { get; set; }
        public bool IsTelefone { get; set; }
        internal bool IsFixedLength { get; set; }
        public bool LettersOnly { get; set; }
        public int FixedLength { get; set; }

        public int MaxLength
        {
            get => this._maxLength;
            set => this._maxLength = value;
        }

        public ValidationAttribute()
        {
            if (this.FixedLength != default)
                this.IsFixedLength = true;
        }

        public ValidationAttribute(string validationMethodName, Type validationClass)
        {
            this._methodName = validationMethodName;
            this._validationClass = validationClass;
        }

        public MethodInfo? GetValidationMethod()
        {
            return this._validationClass?.GetMethod(this._methodName);
        }

        public Type GetValidationClass()
        {
            return this._validationClass;
        }
    }
}
