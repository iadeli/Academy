namespace Academy.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Academy.Persistence.EF.AcademyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Academy.Persistence.EF.AcademyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Course.AddOrUpdate(
                x => x.Title,
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 1" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 2" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 3" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 4" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 5" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 6" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 7" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 8" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 9" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 10" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 11" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 12" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 13" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 14" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 15" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 16" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 17" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 18" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 19" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 20" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 21" },
                new Domain.Model.Courses.Course() { Id = 1, CategoryId = 1, Title = "Develop 22" }
                );
        }
    }
}
