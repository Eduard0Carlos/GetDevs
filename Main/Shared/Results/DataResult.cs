using System.Collections.Generic;

namespace Shared.Results
{
    public class DataResult<T> : Result
    {
        public List<T> Data { get; set; }
        public DataResult()
        {

        }
        public DataResult(string message, bool success, List<T> data)
        {
            this.Message = message;
            this.Success = success;
            this.Data = data;
        }

        public override string ToString()
        {
            return this.Message;
        }
    }
}
