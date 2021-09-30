using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationValidator.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ValidationAttribute : Attribute
    {
        private string _methodName { get; set; }
        private Type _validationClass { get; set; }

        private int _maxLenght = 100;
        public int MaxLenght
        {
            get
            {
                return this._maxLenght;
            }
            set
            {
                this._maxLenght = value;
            }
        }

        public int MinLenght { get; set; }
        public bool HasNormalize { get; set; }
        public bool HasHash { get; set; }
        public bool IsRequired { get; set; }
        public bool IsEmail { get; set; }
        public bool IsCPF { get; set; }
        public bool IsTelefone { get; set; }
        internal bool IsFixedLength { get; set; }
        public bool LettersOnly { get; set; }
        public int FixedLength { get; set; }
        public ValidationAttribute()
        {
            if (this.FixedLength != default)
            {
                this.IsFixedLength = true;
            }
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
