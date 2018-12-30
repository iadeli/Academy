using Academy.Domain.Model.Courses;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Persistence.EF.Mappings
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
        {
            ToTable("Courses");
            HasRequired(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}
