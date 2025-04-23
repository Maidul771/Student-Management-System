namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Registrations", new[] { "BatchID" });
            CreateIndex("dbo.Registrations", "BatchId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Registrations", new[] { "BatchId" });
            CreateIndex("dbo.Registrations", "BatchID");
        }
    }
}
