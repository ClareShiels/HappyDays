namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clubs", "UserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Clubs", "UserID");
            AddForeignKey("dbo.Clubs", "UserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clubs", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Clubs", new[] { "UserID" });
            DropColumn("dbo.Clubs", "UserID");
        }
    }
}
