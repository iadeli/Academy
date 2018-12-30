using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

namespace Academy.Domain.Model.Courses
{
    public interface ICourseRepository
    {
        PagedResult<Course> GetAll(IFilter filter);
    }
}
