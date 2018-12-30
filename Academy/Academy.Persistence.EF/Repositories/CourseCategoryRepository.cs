using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Model;
using Academy.Domain.Model.CourseCategories;
using Framework.Core;

namespace Academy.Persistence.EF.Repositories
{
    public class CourseCategoryRepository : ICourseCategoryRepository , IRepository
    {
        private readonly AcademyContext _context;
        public CourseCategoryRepository(AcademyContext context)
        {
            _context = context;
        }

        public List<CourseCategory> GetAll()
        {
            return _context.CourseCategories.ToList();
        }

        public CourseCategory GetById(long id)
        {
            return _context.CourseCategories.FirstOrDefault(x => x.Id == id);
        }

        public void Save(CourseCategory category)
        {
            //TODO: use unit of work
            _context.CourseCategories.Add(category);
            _context.SaveChanges();
        }
    }
}
