namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNamesChanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Activity", newName: "Activities");
            RenameTable(name: "dbo.Club", newName: "Clubs");
            RenameTable(name: "dbo.Enrolment", newName: "Enrolments");
            RenameTable(name: "dbo.Child", newName: "Children");
            RenameTable(name: "dbo.Payment", newName: "Payments");
            RenameTable(name: "dbo.Instructor", newName: "Instructors");
            AddColumn("dbo.Clubs", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Clubs", "ToBeCollected", c => c.String());
            AddColumn("dbo.Children", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Instructors", "Club_ID", c => c.Int());
            CreateIndex("dbo.Instructors", "Club_ID");
            AddForeignKey("dbo.Instructors", "Club_ID", "dbo.Clubs", "ID");
            DropColumn("dbo.Clubs", "ContactLastName");
            DropColumn("dbo.Children", "GuardianLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Children", "GuardianLastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Clubs", "ContactLastName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Instructors", "Club_ID", "dbo.Clubs");
            DropIndex("dbo.Instructors", new[] { "Club_ID" });
            DropColumn("dbo.Instructors", "Club_ID");
            DropColumn("dbo.Children", "LastName");
            DropColumn("dbo.Clubs", "ToBeCollected");
            DropColumn("dbo.Clubs", "LastName");
            RenameTable(name: "dbo.Instructors", newName: "Instructor");
            RenameTable(name: "dbo.Payments", newName: "Payment");
            RenameTable(name: "dbo.Children", newName: "Child");
            RenameTable(name: "dbo.Enrolments", newName: "Enrolment");
            RenameTable(name: "dbo.Clubs", newName: "Club");
            RenameTable(name: "dbo.Activities", newName: "Activity");
        }
    }
}
