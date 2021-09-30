namespace Shared.Results
{
    public class SingleResult<T> : Result
    {
        public T Value { get; set; }
        public SingleResult()
        {

        }
        public SingleResult(string message, bool success, T value)
        {
            this.Message = message;
            this.Success = success;
            this.Value = value;
        }
        public override string ToString()
        {
            return this.Message;
        }
    }
}
