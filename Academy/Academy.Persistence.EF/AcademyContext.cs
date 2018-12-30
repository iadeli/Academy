using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Model;
using Academy.Domain.Model.CourseCategories;
using System.Data.Common;
using Academy.Domain.Model.Courses;

namespace Academy.Persistence.EF
{
    public class AcademyContext : DbContext
    {
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Course> Course { get; set; }

        public AcademyContext(DbConnection connection) : base(connection, false)
        {
            Database.SetInitializer<AcademyContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(AcademyContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
