using Academy.Domain.Model.CourseCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Model.Courses
{
    public class Course
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public CourseCategory Category { get; set; }
        public long CategoryId { get; set; }
    }
}
