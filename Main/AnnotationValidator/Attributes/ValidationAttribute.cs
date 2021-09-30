using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogical.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class ValidationAttribute : Attribute
    {
        public string MethodName { get; set; }
        public Type ValidationClass { get; set; }
        public int MaxLenght { get; set; } = 100;
        public int MinLenght { get; set; }
        public bool HasNormalize { get; set; }
        public bool HasHash { get; set; }
        public bool IsRequired { get; set; }
        public bool IsEmail { get; set; }
        public bool IsCPF { get; set; }
        public bool IsTelefone { get; set; }
        public bool IsFixedLength { get; set; }
        public bool LettersOnly { get; set; }
        public int FixedLength { get; set; }
        public MethodInfo ValidationMehtod
        {
            get
            {
                return this.ValidationClass?.GetMethod(this.MethodName);
            }
        }
        public ValidationAttribute()
        {
        }
        public ValidationAttribute(string validationMethodName, Type validationClass)
        {
            this.MethodName = validationMethodName;
            this.ValidationClass = validationClass;
        }
    }
}
