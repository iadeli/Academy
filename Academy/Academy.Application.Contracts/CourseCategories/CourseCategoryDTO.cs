namespace Academy.Application.Contracts.CourseCategories
{
    public class CourseCategoryDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
    }
}
