using System.Collections.Generic;
using Academy.Core;
using Framework.Core;
using Framework.Core.Permissions;

namespace Academy.Application.Contracts.CourseCategories
{    
    public interface ICourseCategoryService : IService
    {
        [NeedPermission(AcademyPermissions.ViewCourseCategory)]
        List<CourseCategoryDTO> GetAll();

        [NeedPermission(AcademyPermissions.CreateCourseCategory)]
        void CreateChild(string title, long parentId);

        [NeedPermission(AcademyPermissions.CreateCourseCategory)]
        void CreateRoot(string title);
    }
}
