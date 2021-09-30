using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogical.Factory;

namespace BusinessLogical.Enxtensions
{
    public static class StringExtension
    {
        #region Validations
        public static ValidationResult ValidateCPF(this string cpf)
        {
            for (int i = 0; i < cpf.Length; i++)
            {
                if (!char.IsNumber(cpf[i]))
                {
                    return ValidationResultFactory.CreateFailureCPFValidationResult();
                }
            }
            cpf = cpf.NormalizeCPF();
            if (cpf.Length != 11)
            {
                return ValidationResultFactory.CreateFailureCPFValidationResult();
            }
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            if (cpf.EndsWith(digito))
            {
                return ValidationResultFactory.CreateSuccessValidationResult();
            }
            return ValidationResultFactory.CreateFailureCPFValidationResult();
        }
        public static ValidationResult ValidateEmail(this string email)
        {
            return !Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$") ? ValidationResultFactory.CreateFailureEmailValidationResult() : ValidationResultFactory.CreateSuccessValidationResult();
        }
        public static ValidationResult ValidateLength(this string str, int maxLength, int minLength, string fieldName)
        {
            if (str.Length > maxLength || str.Length < minLength)
            {
                return ValidationResultFactory.CreateFailureLengthValidationResult(maxLength, minLength, fieldName);
            }
            return ValidationResultFactory.CreateSuccessValidationResult();
        }
        public static ValidationResult ValidateLength(this string str, int lenght, string fieldName)
        {
            if (str.Length != lenght)
            {
                return ValidationResultFactory.CreateFailureFixLengthValidationResult(fieldName, lenght);
            }
            return ValidationResultFactory.CreateSuccessValidationResult();
        }
        public static ValidationResult ValidateTelefone(this string str)
        {
            if (!Regex.IsMatch(str, @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$"))
            {
                return ValidationResultFactory.CreateFailureTelefoneValidationResult();
            }
            return ValidationResultFactory.CreateSuccessValidationResult();
        }
        public static ValidationResult ContainsOnlyLetters(this string str, string fieldName)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]) && str[i] != '\'')
                {
                    return new ValidationResult($"{fieldName} deve conter apenas letras", false);
                }
            }
            return ValidationResultFactory.CreateSuccessValidationResult();
        }
        #endregion

        #region Normalizations
        public static string NormalizeString(this string str)
        {
            str = Regex.Replace(str, @"\s+", " ");
            str = str.Trim();
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            str = textInfo.ToTitleCase(str);
            return str;
        }
        public static string NormalizeCPF(this string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            cpf = Regex.Replace(cpf, @"\s+", "");
            cpf = cpf.Trim();
            return cpf;
        }
        public static string NormalizeEmail(string email)
        {
            email = Regex.Replace(email, @"\s+", "");
            email = email.Trim();
            return email;
        }
        public static string NormalizeRG(string rg)
        {
            rg = rg.Replace(".", "").Replace("-", "");
            rg = Regex.Replace(rg, @"\s+", "");
            rg = rg.Trim();
            return rg;
        }
        #endregion
    }
}
