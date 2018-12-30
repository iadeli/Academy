using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Permissions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NeedPermissionAttribute : Attribute
    {
        public object Permission { get; set; }

        public NeedPermissionAttribute(object permission)
        {
            Permission = permission;

            if (!permission.GetType().IsEnum)
                throw new Exception("Permission should be an enum :|");
        }
    }
}
