using System.Collections.Generic;

namespace Shared.Results
{
    public static class ResultFactory
    {
        private static string _successMessage = "Success";
        private static string _failureMessage = "Failure";

        public static Result CreateSuccessResult()
        {
            return new Result() { Message = _successMessage, Success = true };
        }

        public static Result CreateFailureResult()
        {
            return new Result() { Message = _failureMessage, Success = false };
        }

        public static DbResult CreateSuccessDbResult(int id)
        {
            return new DbResult() { Message = _successMessage, Success = true, ID = id };
        }

        public static DbResult CreateFailureDbResult()
        {
            return new DbResult() { Message = _failureMessage, Success = false };
        }

        public static DbResult CreateFailureDbResult(string message)
        {
            return new DbResult() { Message = message, Success = false };
        }

        public static SingleResult<T> CreateSuccessSingleResult<T>(T obj)
        {
            return new SingleResult<T>() { Message = _successMessage, Success = true, Value = obj };
        }

        public static SingleResult<T> CreateFailureSingleResult<T>()
        {
            return new SingleResult<T>() { Message = _failureMessage, Success = false };
        }

        public static DataResult<T> CreateSuccessDataResult<T>(params T[] objects)
        {
            var dataResult = new DataResult<T>() { Message = _successMessage, Success = true };

            foreach (var obj in objects)
            {
                dataResult.Data.Add(obj);
            }

            return dataResult;
        }

        public static DataResult<T> CreateSuccessDataResult<T>(List<T> objectList)
        {
            return new DataResult<T>() { Message = _successMessage, Success = true, Data = objectList };
        }

        public static DataResult<T> CreateFailureDataResult<T>()
        {
            return new DataResult<T>() { Message = _failureMessage, Success = false };
        }

        public static Result CreateFailureOperationResult()
        {
            return new Result("Operação invalida", false);
        }

        public static Result CreateFailureCPFValidationResult()
        {
            return new Result("CPF inválido", false);
        }
        public static Result CreateFailureTelefoneValidationResult()
        {
            return new Result("Telefone inválido", false);
        }
        public static Result CreateSuccessValidationResult()
        {
            return new Result("Validação realizada com sucesso", true);
        }
        public static Result CreateFailureEmailValidationResult()
        {
            return new Result("Email inválido", false);
        }
        public static Result CreateFailureLengthValidationResult(int maxLength, int minLength, string propertyName)
        {
            if (maxLength == minLength)
            {
                return new Result($"{propertyName} deve possuir {maxLength} caracteres", false);
            }
            return new Result($"{propertyName} deve possuir entre {minLength} e {maxLength} caracteres", false);
        }
        public static Result CreateFailureNomeValidationResult(string nomeCampo)
        {
            return new Result($"O campo {nomeCampo} deve possuir apenas letras", false);
        }

        public static Result CreateFailureIdadeValidation()
        {
            return new Result("O cliente deve possuir ao menos 16 anos", false);
        }

        public static Result CreateFailureCepValidation()
        {
            return new Result("CEP inválido", false);
        }
        public static Result CreateFailureProfissionalAccessValidatioResult()
        {
            return new Result("O usuario atual não tem permissão para usar esta funcionalidade", false);
        }
    }
}
