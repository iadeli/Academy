using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Contracts
{
    public interface IAuthenticationService
    {
        ClaimsIdentity Authenticate(string username, string password);
    }
}
