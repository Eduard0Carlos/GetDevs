using Domain.Entities;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResult> Authenticate(AuthenticateRequest model);
    }
}
