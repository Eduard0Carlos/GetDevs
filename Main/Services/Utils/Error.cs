using Shared.Results;
using System;

namespace Services.Utils
{
    public class Error
    {
        public static Result asdfg(Exception ex)
        {
            return ResultFactory.CreateFailureResult();
        }
    }
}
