using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Model.Courses;
using System.Data.Entity;
using Framework.Core;

namespace Academy.Persistence.EF.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademyContext _context;
        private readonly IFilterService _filterService;
        public CourseRepository(AcademyContext context, IFilterService filterService)
        {
            _context = context;
            _filterService = filterService;
        }
        public PagedResult<Course> GetAll(IFilter filter)
        {
            var query = _context.Course.Include(a => a.Category).AsQueryable();
            return _filterService.ApplyFilter(query, filter);
        }
    }
}
