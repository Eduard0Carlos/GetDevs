using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogical.Factory
{
    public class ValidationResultFactory
    {
        private static string _successMessage = "Success";
        private static string _failureMessage = "Failure";

        public static ValidationResult CreateFailureValidationResult()
        {
            return new ValidationResult() { Message = _failureMessage, Success = false };
        }
        public static ValidationResult CreateFailureOperationValidationResult()
        {
            return new ValidationResult("Operação invalida", false);
        }

        public static ValidationResult CreateFailureCPFValidationResult()
        {
            return new ValidationResult("CPF inválido", false);
        }
        public static ValidationResult CreateFailureTelefoneValidationResult()
        {
            return new ValidationResult("Telefone inválido", false);
        }
        public static ValidationResult CreateSuccessValidationResult()
        {
            return new ValidationResult("Validação realizada com sucesso", true);
        }
        public static ValidationResult CreateFailureEmailValidationResult()
        {
            return new ValidationResult("Email inválido", false);
        }
        public static ValidationResult CreateFailureLengthValidationResult(int maxLength, int minLength, string propertyName)
        {
            return new ValidationResult($"{propertyName} deve possuir entre {minLength} e {maxLength} caracteres", false);
        }
        public static ValidationResult CreateFailureFixLengthValidationResult(string propertyName, int lenght)
        {
            return new ValidationResult($"{propertyName} deve possuir {lenght} caracteres!", false);
        }
        public static ValidationResult CreateFailureNomeValidationResult(string nomeCampo)
        {
            return new ValidationResult($"O campo {nomeCampo} deve possuir apenas letras", false);
        }

        public static ValidationResult CreateFailureIdadeValidationResult()
        {
            return new ValidationResult("O cliente deve possuir ao menos 16 anos", false);
        }

        public static ValidationResult CreateFailureCepValidationResult()
        {
            return new ValidationResult("CEP inválido", false);
        }
        public static ValidationResult CreateFailureProfissionalAccessValidationResult()
        {
            return new ValidationResult("O usuario atual não tem permissão para usar esta funcionalidade", false);
        }
    }
}
