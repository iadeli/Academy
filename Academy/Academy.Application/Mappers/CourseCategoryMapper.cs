using Academy.Application.Contracts;
using Academy.Domain.Model.CourseCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Application.Contracts.CourseCategories;

namespace Academy.Application.Mappers
{
    public static class CourseCategoryMapper
    {
        public static List<CourseCategoryDTO> Map (List<CourseCategory> entities)
        {
            //return entities.Select(a => Map(a)).ToList();
            return entities.Select(Map).ToList();
        }

        public static CourseCategoryDTO Map(CourseCategory entities)
        {
            return entities == null ? null : new CourseCategoryDTO() { Id = entities.Id, ParentId = entities.Parent?.Id, Title = entities.Title };
        }
    }
}
