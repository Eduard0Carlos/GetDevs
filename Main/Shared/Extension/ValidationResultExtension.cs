using AnnotationValidator.Results;
using Shared.Results;

namespace Shared.Extension
{
    public static class ValidationResultExtension
    {
        public static Result ToResult(this ValidationResult result)
        {
            return new Result (message: result.Message, success: result.IsValid );
        }
    }
}
