namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Registrations", "CourseId");
            CreateIndex("dbo.Registrations", "BatchID");
            AddForeignKey("dbo.Registrations", "BatchID", "dbo.Batches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Registrations", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Registrations", "BatchID", "dbo.Batches");
            DropIndex("dbo.Registrations", new[] { "BatchID" });
            DropIndex("dbo.Registrations", new[] { "CourseId" });
        }
    }
}
