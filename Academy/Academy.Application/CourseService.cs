using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Application.Contracts;
using Academy.Application.Contracts.Courses;
using Academy.Application.Mappers;
using Academy.Domain.Model.Courses;
using Framework.Core;

namespace Academy.Application
{
    public class CourseService : ICourseService 
    {
        private readonly ICourseRepository _repository;
        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public PagedResult<CourseDTO> GetAll(IFilter filter)
        {
            var courseList = _repository.GetAll(filter);
            var mapped = CourseMapper.Map(courseList.Data);
            return new PagedResult<CourseDTO>(mapped, courseList.Total);
        }
    }
}
