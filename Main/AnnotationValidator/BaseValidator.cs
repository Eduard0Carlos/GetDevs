using BusinessLogical.Attributes;
using BusinessLogical.Enxtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogical
{
    public class BaseValidator<Entity>
    {
        public Type ValidationModel { get; set; }
        private StringBuilder _erros = new StringBuilder();
        protected void AddErro(string erro)
        {
            this._erros.AppendLine(erro);
        }
        public virtual ValidationResult Validate(Entity entity)
        {
            PropertyInfo[] properties = typeof(Entity).GetProperties();
            List<ValidationResult> results = new List<ValidationResult>();
            PropertyInfo[] validationProperties = this.ValidationModel.GetProperties();
            foreach (var property in properties)
            { 
                var validationProperty = validationProperties.ToList().Find(item => item.Name == property.Name);
                var validationAttribute = validationProperty?.GetCustomAttribute<ValidationAttribute>();
                if (validationAttribute != null)
                {
                    var validationMethod = validationAttribute.ValidationMehtod;
                    if (validationAttribute.IsRequired && (property.GetValue(entity) == default || string.IsNullOrWhiteSpace((property.GetValue(entity) as string))))
                    {
                        results.Add(new ValidationResult($"{property.Name} deve ser informado", false));
                    }
                    else if (validationMethod != null)
                    {
                        var validation = new ValidationResult();
                        if (validationMethod.DeclaringType.IsAbstract)
                        {
                            validation = (validationMethod.Invoke(null, new[] { property.GetValue(entity) }) as ValidationResult);
                        }
                        else
                        {
                            validation = ((validationMethod.Invoke(Activator.CreateInstance(validationAttribute.ValidationClass), new[] { property.GetValue(entity) }) as ValidationResult));
                        }
                        if (!validation.Success)
                        {
                            results.Add(validation);
                        }
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        var value = (property.GetValue(entity) as string);
                        if (validationAttribute.LettersOnly)
                        {
                            results.Add(value.ContainsOnlyLetters(property.Name));
                        }
                        if (validationAttribute.IsTelefone)
                        {
                            results.Add(value.ValidateTelefone());
                        }
                        else if (validationAttribute.IsEmail)
                        {
                            results.Add(value.ValidateEmail());
                        }
                        else if (validationAttribute.IsCPF)
                        {
                            results.Add(value.ValidateCPF());
                        }
                        if (validationAttribute.IsFixedLength)
                        {
                            results.Add(value.ValidateLength(validationAttribute.FixedLength, property.Name));
                        }
                        else
                        {
                            results.Add((value.ValidateLength(validationAttribute.MaxLenght, validationAttribute.MinLenght, property.Name)));
                        }
                        if (validationAttribute.HasNormalize)
                        {
                            property.SetValue(entity, value.NormalizeString());
                        }
                        if (validationAttribute.HasHash)
                        {
                            property.SetValue(entity, this.HashString(value));
                        }
                    }
                }
            }
            this.ValidateResult(results.ToArray());
            return this.CheckErros();
        }

        private ValidationResult CheckErros()
        {
            if (this._erros.Length != 0)
            {
                ValidationResult response = new ValidationResult() { Message = this._erros.ToString(), Success = false };
                this._erros.Clear();
                return response;
            }
            return new ValidationResult("Nenhum erro encontrado", true);
        }
        private void ValidateResult(params ValidationResult[] results)
        {
            for (int i = 0; i < results.Length; i++)
            {
                if (!results[i].Success)
                {
                    this.AddErro(results[i].Message);
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
    }
}
