using Shared.Results;

namespace Shared.Utils
{
    internal static class ResultExtension
    {
        public static Result ToResult(this Result result)
        {
            return new Result (message: result.Message, success: result.Success );
        }
    }
}
