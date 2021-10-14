using AnnotationValidator.Attribute;
using AnnotationValidator.Attributes;
using AnnotationValidator.Enxtensions;
using AnnotationValidator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace AnnotationValidator
{
    public class BaseValidator<TEntity>
    {
        private bool _isValidatePropertyActive;
        private string _validationPropertyName;
        private StringBuilder _errors;

        public Type ValidationModel { get; set; }

        public BaseValidator()
        {
            this._errors = new StringBuilder();
        }

        protected void AddError(string error)
        {
            this._errors.AppendLine(error);
        }

        public virtual ValidationResult Validate(TEntity entity)
        {
            var entityProperties = typeof(TEntity).GetProperties();
            var validationResults = new List<ValidationResult>();
            var validationProperties = this.ValidationModel.GetProperties();

            foreach (var property in entityProperties)
            {
                PropertyInfo validationProperty;
            
                if (this._isValidatePropertyActive)
                    validationProperty = validationProperties.ToList().Find(item => item.Name == this._validationPropertyName);
                else
                    validationProperty = validationProperties.ToList().Find(item => item.Name == property.Name);
                
                var validationAttribute = validationProperty?.GetCustomAttribute<ValidationAttribute>();
                
                if (validationAttribute != null)
                {
                    var validationMethod = validationAttribute.GetValidationMethod();
                    if (validationAttribute.IsRequired && (property.GetValue(entity) == default))
                        validationResults.Add(ValidationResultFactory.CreateFailure($"{property.Name} deve ser informado"));
                
                    else if (validationMethod != null)
                    {
                        var validation = new ValidationResult();
                        if (validationMethod.DeclaringType.IsAbstract)
                            validation = (validationMethod.Invoke(null, new[] { property.GetValue(entity) }) as ValidationResult);
                        else
                            validation = ((validationMethod.Invoke(Activator.CreateInstance(validationAttribute.GetValidationClass()), new[] { property.GetValue(entity) }) as ValidationResult));
                    
                        if (!validation.IsValid)
                            validationResults.Add(validation);
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        var displayName = property.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                        if (displayName == null)
                            displayName = property.Name;

                        var value = (property.GetValue(entity) as string);
                        if (string.IsNullOrWhiteSpace(value))
                            validationResults.Add(ValidationResultFactory.CreateFailure());

                        if (validationAttribute.LettersOnly)
                            validationResults.Add(value.ContainsOnlyLetters(displayName));
                        
                        if (validationAttribute.IsTelefone)
                            validationResults.Add(value.ValidatePhoneNumber());
                        
                        else if (validationAttribute.IsEmail)
                            validationResults.Add(value.ValidateEmail());
                        
                        else if (validationAttribute.IsCPF)
                            validationResults.Add(value.ValidateCPF());
                        
                        if (validationAttribute.IsFixedLength)
                            validationResults.Add(value.ValidateLength(validationAttribute.FixedLength, displayName));
                        else
                            validationResults.Add((value.ValidateLength(validationAttribute.MaxLength, validationAttribute.MinLength, displayName)));
                     
                        if (validationAttribute.HasNormalize)
                            property.SetValue(entity, value.NormalizeString());
                        
                        if (validationAttribute.HasHash)
                            property.SetValue(entity, this.HashString(value));
                    }
                }
                if (this._isValidatePropertyActive)
                {
                    this._isValidatePropertyActive = false;
                    break;
                }
            }

            this.ValidateResult(validationResults.ToArray());
            
            return this.CheckErros();
        }

        private ValidationResult CheckErros()
        {
            if (this._errors.Length != 0)
            {
                var response = ValidationResultFactory.CreateFailure(message: this._errors.ToString(), errorCount: this._errors.Length);
                this._errors.Clear();

                return response;
            }
            return ValidationResultFactory.CreateSuccess("Nenhum erro encontrado");
        }
        private void ValidateResult(params ValidationResult[] validationResults)
        {
            for (int i = 0; i < validationResults.Length; i++)
            {
                if (!validationResults[i].IsValid)
                {
                    this.AddError(validationResults[i].Message);
                }
            }
        }
        public virtual string HashString(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var password = Encoding.ASCII.GetBytes(value);
            var md5data = md5.ComputeHash(password);
            var hashedPassword = ASCIIEncoding.ASCII.GetString(md5data);

            return hashedPassword;
        }
        public virtual ValidationResult ValidateProperty(string propertyName, TEntity entity)
        {
            this._isValidatePropertyActive = true;
            this._validationPropertyName = propertyName;
            
            return this.Validate(entity);
        }
    }
}
