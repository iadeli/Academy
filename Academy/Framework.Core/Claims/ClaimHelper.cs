using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.Claims
{
    public class ClaimHelper
    {
        public static string GetCurrentRole()
        {
            return Get<string>(ClaimTypes.Role);
        }

        public static T Get<T>(string claimType)
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            if (identity == null) return default(T);

            var claim = identity.Claims.FirstOrDefault(a => a.Type == claimType);
            if (claim == null) return default(T);

            return (T) Convert.ChangeType(claim.Value, typeof(T));
        }
    }
}
