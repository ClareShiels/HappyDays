namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildPermissionToLeaveProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "PermissionToLeave", c => c.Boolean(nullable: false));
            DropColumn("dbo.Clubs", "ToBeCollected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clubs", "ToBeCollected", c => c.String());
            DropColumn("dbo.Children", "PermissionToLeave");
        }
    }
}
