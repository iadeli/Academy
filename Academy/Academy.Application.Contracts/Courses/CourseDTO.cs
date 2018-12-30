using Academy.Application.Contracts.CourseCategories;

namespace Academy.Application.Contracts.Courses
{
    public class CourseDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public CourseCategoryDTO Category { get; set; }
    }
}
