using System;

namespace Framework.Core.Permissions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IgnorePermissionAttribute : Attribute
    {
    }
}
