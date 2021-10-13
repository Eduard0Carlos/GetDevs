using System.Text.RegularExpressions;
using System.Threading;
using Shared.Results;

namespace AnnotationValidator.Enxtensions
{
    public static class StringExtension
    {
        #region Validations
        public static ValidationResult ValidateCPF(this string cpf)
        {
            var failureMessage = "CPF inválido!";

            for (int i = 0; i < cpf.Length; i++)
            {
                if (!char.IsNumber(cpf[i]))
                    return ValidationResultFactory.CreateFailure(failureMessage);
            }

            cpf = cpf.NormalizeCPF();
            
            if (cpf.Length != 11)
                return ValidationResultFactory.CreateFailure(failureMessage);
            
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
                return ValidationResultFactory.CreateSuccess();
            
            return ValidationResultFactory.CreateFailure(failureMessage);
        }
        public static ValidationResult ValidateEmail(this string email)
        {
            var failureMessage = "Email inválido!";
            return !Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$") ? 
                ValidationResultFactory.CreateFailure(failureMessage) : 
                ValidationResultFactory.CreateSuccess();
        }
        public static ValidationResult ValidateLength(this string str, int maxLength, int minLength, string fieldName)
        {
            var failureMessage = $"{fieldName} deve conter entre {minLength} e {maxLength}";

            if (str.Length > maxLength || str.Length < minLength)
                return ValidationResultFactory.CreateFailure(failureMessage);
        
            return ValidationResultFactory.CreateSuccess();
        }
        public static ValidationResult ValidateLength(this string str, int lenght, string fieldName)
        {
            var failureMessage = $"{fieldName} deve conter {lenght}";

            if (str.Length != lenght)
                return ValidationResultFactory.CreateFailure(failureMessage);

            return ValidationResultFactory.CreateSuccess();
        }

        public static ValidationResult ValidatePhoneNumber(this string str)
        {
            var failureMessage = "Telefone inválido!";

            if (!Regex.IsMatch(str, @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$"))
                return ValidationResultFactory.CreateFailure(failureMessage);
            
            return ValidationResultFactory.CreateSuccess();
        }

        public static ValidationResult ContainsOnlyLetters(this string str, string fieldName)
        {
            var failureMessage = $"{fieldName} deve conter apenas letras.";

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]) && str[i] != '\'')
                    return ValidationResultFactory.CreateFailure(failureMessage);
            }

            return ValidationResultFactory.CreateSuccess();
        }
        #endregion

        #region Normalizations
        public static string NormalizeString(this string str)
        {
            str = Regex.Replace(str, @"\s+", " ")
                .Trim();
            var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            str = textInfo.ToTitleCase(str);
            
            return str;
        }

        public static string NormalizeCPF(this string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            cpf = Regex.Replace(cpf, @"\s+", "")
                .Trim();
            
            return cpf;
        }

        public static string NormalizeEmail(string email)
        {
            email = Regex.Replace(email, @"\s+", "")
                .Trim();

            return email;
        }

        public static string NormalizeRG(string rg)
        {
            rg = rg.Replace(".", "").Replace("-", "");
            rg = Regex.Replace(rg, @"\s+", "")
                .Trim();

            return rg;
        }
        #endregion
    }
}
