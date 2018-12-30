using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Academy.Application.Contracts;
using Academy.Application.Contracts.CourseCategories;
using Academy.Domain.Model;
using Academy.Domain.Model.CourseCategories;
using Framework.Core;

namespace Academy.Application
{
    public class CourseCategoryService : ICourseCategoryService, IService
    {
        private readonly ICourseCategoryRepository _repository;
        public CourseCategoryService(ICourseCategoryRepository repository)
        {
            _repository = repository;
        }

        public List<CourseCategoryDTO> GetAll()
        {
            var listOfCourseCategory = _repository.GetAll();
            return Mappers.CourseCategoryMapper.Map(listOfCourseCategory);
        }

        public void CreateRoot(string title)
        {
            //1. Create domain model instance
            var rootCategory = CourseCategory.CreateRootCategory(title);

            //2. Save into database
            _repository.Save(rootCategory);
        }

        public void CreateChild(string title, long parentId)
        {
            //1. Load parent
            var category = _repository.GetById(parentId);

            //2. Call createChild method
            var child = category.CreateChild(title);

            //3. Save instance into database
            _repository.Save(child);
        }
    }
}
