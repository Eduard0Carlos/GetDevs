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
    }
}
