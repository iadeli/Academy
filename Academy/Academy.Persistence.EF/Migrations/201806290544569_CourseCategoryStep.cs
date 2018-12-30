namespace Academy.Persistence.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseCategoryStep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseCategories", "ParentId", "dbo.CourseCategories");
            DropIndex("dbo.CourseCategories", new[] { "ParentId" });
            DropTable("dbo.CourseCategories");
        }
    }
}
