using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Model.CourseCategories
{
    public interface ICourseCategoryValidator
    {
        bool CanChangeParentTo(CourseCategory category, CourseCategory parent);
    }
}
