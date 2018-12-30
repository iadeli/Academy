using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core
{
    public static class PermissionProvider
    {
        public static Dictionary<string, List<AcademyPermissions>> GetPermission()
        {
            //TODO: Move to a data store
            return new Dictionary<string, List<AcademyPermissions>>()
            {
                {
                    "Admin", new List<AcademyPermissions>()
                    {
                        AcademyPermissions.CreateCourseCategory,
                        AcademyPermissions.ModifyCourseCategory,
                        AcademyPermissions.ViewCourseCategory,
                        AcademyPermissions.DeleteCourseCategory
                    }
                },
                {
                    "Moderator", new List<AcademyPermissions>()
                    {
                        AcademyPermissions.ModifyCourseCategory,
                        AcademyPermissions.ViewCourseCategory
                    }
                }
            };
        }
    }
}
