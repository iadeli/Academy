using System;
using Academy.Domain.Model.CourseCategories.Exceptions;

namespace Academy.Domain.Model.CourseCategories
{
    public class CourseCategory
    {
        public long Id { get; set; }
        public string Title { get; private set; }
        public bool IsActive { get; private set; }
        public CourseCategory Parent { get; private set; }

        //For EF :|
        protected CourseCategory()
        {
        }

        private CourseCategory(string title, CourseCategory parent = null)
        {
            this.Title = title;
            this.Parent = parent;
            this.IsActive = true;
        }

        public static CourseCategory CreateRootCategory(string title)
        {
            return new CourseCategory(title, null);
        }

        public CourseCategory CreateChild(string title)
        {
            if (!this.IsActive) throw new InvalidCourseCategoryStateException();
            return new CourseCategory(title, this);
        }

        public void Deactive()
        {
            this.IsActive = false;
        }

        public void ChangeParent(CourseCategory parent, ICourseCategoryValidator validator)
        {
            if (validator.CanChangeParentTo(this, parent))
                this.Parent = parent;
            else
                throw new Exception();
        }
    }
}
