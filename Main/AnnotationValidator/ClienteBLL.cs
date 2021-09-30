using BusinessLogical.ValidationModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogical
{
    public class ClienteBLL : BaseValidator<Cliente>
    {
        public ClienteBLL()
        {
            this.ValidationModel = typeof(ClienteValidationModel);
        }
        public ValidationResult Insert(Cliente cliente)
        {
            return this.Validate(cliente);
        }
    }
}
