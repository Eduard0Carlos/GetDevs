using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogical
{
    public class ValidationResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public int ErrorConut { get; set; }

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
