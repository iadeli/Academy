using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Model;

namespace UserManagement.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthenticationService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public ClaimsIdentity Authenticate(string username, string password)
        {
            var user = _userManager.Find(username, password);
            return CreateClaimsIdentity(user);
        }

        private ClaimsIdentity CreateClaimsIdentity(IdentityUser user)
        {
            if (user == null) return null;
            return new ClaimsIdentityFactory<IdentityUser>().CreateAsync(_userManager, user, "ApplicationCookie").Result;
        }
    }
}
