using Shared.Results;

namespace Shared.Útils
{
    internal static class ResultExtension
    {
        public static Result ToDefaultResult(this Result result)
        {
            return new Result { Message = result.Message, Success = result.Success };
        }
    }
}
