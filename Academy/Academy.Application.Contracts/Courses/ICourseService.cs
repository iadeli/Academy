using Framework.Core;
using Framework.Core.Permissions;

namespace Academy.Application.Contracts.Courses
{    
    public interface ICourseService : IService
    {
        [IgnorePermission]
        PagedResult<CourseDTO> GetAll(IFilter filter);
    }
}
