namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIDChildTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Children", "UserID");
            AddForeignKey("dbo.Children", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Children", new[] { "UserID" });
            DropColumn("dbo.Children", "UserID");
        }
    }
}
