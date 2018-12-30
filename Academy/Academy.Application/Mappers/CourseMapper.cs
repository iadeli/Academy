using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Application.Contracts;
using Academy.Application.Contracts.Courses;
using Academy.Domain.Model.Courses;
using Framework.Core;

namespace Academy.Application.Mappers
{
    public class CourseMapper
    {
        public static CourseDTO Map(Course entity)
        {
            return new CourseDTO()
            {
                Id = entity.Id,
                Title = entity.Title,
                Category = Mappers.CourseCategoryMapper.Map(entity.Category)
            };
        }

        public static List<CourseDTO> Map(List<Course> entities)
        {
            return entities.Select(Map).ToList();
        }
    }
}
