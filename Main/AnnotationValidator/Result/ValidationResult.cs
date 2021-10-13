namespace Shared.Results
{
    public class ValidationResult
    {
        public string Message { get; set; }
        public bool IsValid { get; set; }
        public int ErrorCount { get; set; }

        public ValidationResult() { }

        public ValidationResult(string message, bool isValid, int errorCount)
        {
            this.Message = message;
            this.IsValid = isValid;
            this.ErrorCount = errorCount;
        }
    }

    public static class ValidationResultFactory
    {
        public static ValidationResult CreateSuccess(string message = "Success!", bool isValid = true, int errorCount = 0)
        {
            return new ValidationResult(message, isValid, errorCount);
        }
        
        public static ValidationResult CreateFailure(string message = "Failure!", bool isValid = false, int errorCount = 0)
        {
            return new ValidationResult(message, isValid, errorCount);
        }
    }
}
