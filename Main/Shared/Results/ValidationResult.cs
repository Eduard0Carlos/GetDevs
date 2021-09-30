namespace Shared.Results
{
    public class ValidationResult : Result
    {
        public int ErrorCount { get; set; }

        public ValidationResult(string message, bool success)
        {
            this.Message = message;
            this.Success = success;
        }
        public ValidationResult()
        {

        }
    }
}
