namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activitymodelchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "MaxCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.Activities", "PriceOfActivity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Clubs", "ClubEmail", c => c.String(nullable: false));
            AddColumn("dbo.Clubs", "EirCode", c => c.String());
            AddColumn("dbo.Children", "EirCode", c => c.String());
            AlterColumn("dbo.Clubs", "ContactPhNo", c => c.String(nullable: false));
            AlterColumn("dbo.Clubs", "ClubName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Children", "GuardianPhNo", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "ChildLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "ChildFirstName", c => c.String(nullable: false));
            DropColumn("dbo.Clubs", "ContactEmail");
            DropColumn("dbo.Clubs", "PostalCode");
            DropColumn("dbo.Children", "PostalCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Children", "PostalCode", c => c.String());
            AddColumn("dbo.Clubs", "PostalCode", c => c.String());
            AddColumn("dbo.Clubs", "ContactEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Children", "ChildFirstName", c => c.String());
            AlterColumn("dbo.Children", "ChildLastName", c => c.String());
            AlterColumn("dbo.Children", "GuardianPhNo", c => c.String());
            AlterColumn("dbo.Clubs", "ClubName", c => c.String());
            AlterColumn("dbo.Clubs", "ContactPhNo", c => c.String());
            DropColumn("dbo.Children", "EirCode");
            DropColumn("dbo.Clubs", "EirCode");
            DropColumn("dbo.Clubs", "ClubEmail");
            DropColumn("dbo.Activities", "PriceOfActivity");
            DropColumn("dbo.Activities", "MaxCapacity");
        }
    }
}
