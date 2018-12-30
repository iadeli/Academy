using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Model;
using Academy.Domain.Model.CourseCategories;

namespace Academy.Persistence.EF.Mappings
{
    public class CourseCategoryMapping : EntityTypeConfiguration<CourseCategory>
    {
        public CourseCategoryMapping()
        {
            ToTable("CourseCategories");
            HasOptional(x => x.Parent).WithMany().Map(x => x.MapKey("ParentId"));
        }        
    }   
}
