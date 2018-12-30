using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Model.CourseCategories
{
    public interface ICourseCategoryRepository
    {
        CourseCategory GetById(long id);
        void Save(CourseCategory category);
        List<CourseCategory> GetAll();
    }
}
