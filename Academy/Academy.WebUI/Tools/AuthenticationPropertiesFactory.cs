using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.WebUI.Tools
{
    public class AuthenticationPropertiesFactory
    {
        public static AuthenticationProperties Create(bool rememberMe)
        {
            return new AuthenticationProperties() { ExpiresUtc = DateTime.Now.AddYears(1), IsPersistent = true };
        }
    }
}