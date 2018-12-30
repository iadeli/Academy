namespace Academy.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.CourseCategories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.Courses");
        }
    }
}
