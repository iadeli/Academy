using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Framework.Core.Claims;
using Framework.Core.Permissions;
using Academy.Core;

namespace Academy.Config
{
    public class SecurityInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var attributes = invocation.Method.GetCustomAttributes();
            if (ShouldIgnorePermission(attributes))
            {
                //Before method call
                invocation.Proceed();
                //After method call
                return;
            }

            var neededPermission = ExtractNeededPermission(attributes);
            if (neededPermission == null) throw new InvalidAccessGrantException();

            if (!UserHasPermission(neededPermission)) throw new InvalidAccessGrantException();

            invocation.Proceed();
        }

        private bool UserHasPermission(NeedPermissionAttribute neededPermission)

        {
            //TODO: refeactor this method
            var role = ClaimHelper.GetCurrentRole();
            if (role == null) return false;
            var permissionOfCurrentRole = PermissionProvider.GetPermission()
                .First(a => a.Key.Equals(role, StringComparison.OrdinalIgnoreCase));
            return permissionOfCurrentRole.Value.Contains((AcademyPermissions) neededPermission.Permission);
        }

        private NeedPermissionAttribute ExtractNeededPermission(IEnumerable<Attribute> invocation)
        {
            return invocation.OfType<NeedPermissionAttribute>().FirstOrDefault();
        }

        private bool ShouldIgnorePermission(IEnumerable<Attribute> invocation)
        {
            return invocation.OfType<IgnorePermissionAttribute>().Any();
        }
    }
}
