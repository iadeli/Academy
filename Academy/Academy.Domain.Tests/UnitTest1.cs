using System;
using Academy.Domain.Model;
using Academy.Domain.Model.CourseCategories.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Academy.Domain.Model.CourseCategories;

namespace Academy.Domain.Tests
{
    [TestClass]
    public class CourseCategoryTests
    {
        [TestMethod]
        public void When_creating_root_coursecategory_parent_should_be_null()
        {
            var courseCategory = CourseCategory.CreateRootCategory("Web Programming");
            Assert.IsNull(courseCategory.Parent);
        }

        [TestMethod]
        public void When_creating_child_course_category_parent_should_be_not_null()
        {
            var parentCategory = CourseCategory.CreateRootCategory("Programming");
            var child = parentCategory.CreateChild("Web Programming");
            Assert.IsNotNull(child.Parent);
        }

        [TestMethod]
        public void When_course_category_is_not_active_create_child_should_be_throw_exception()
        {
            var category = CourseCategory.CreateRootCategory("Programming");
            category.Deactive();

            Assert.ThrowsException<InvalidCourseCategoryStateException>(() =>
            {
                var child = category.CreateChild("Web Programming");
            });
        }
    }
}
