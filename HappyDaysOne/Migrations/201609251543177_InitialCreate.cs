namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameOfActivity = c.String(nullable: false),
                        AgeGroup = c.Int(nullable: false),
                        ActivityType = c.Int(nullable: false),
                        ActivityCourseStartDate = c.DateTime(nullable: false),
                        ActivityCourseEndDate = c.DateTime(nullable: false),
                        Day = c.Int(nullable: false),
                        ClassTime = c.DateTime(nullable: false),
                        ClubID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Club", t => t.ClubID, cascadeDelete: true)
                .Index(t => t.ClubID);
            
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        ContactLastName = c.String(nullable: false, maxLength: 50),
                        ContactPhNo = c.String(),
                        ContactEmail = c.String(nullable: false),
                        ClubName = c.String(),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(nullable: false),
                        County = c.String(nullable: false),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enrolment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentReceived = c.Boolean(nullable: false),
                        PaymentDue = c.Boolean(nullable: false),
                        ChildID = c.Int(nullable: false),
                        ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activity", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Child", t => t.ChildID, cascadeDelete: true)
                .Index(t => t.ChildID)
                .Index(t => t.ActivityID);
            
            CreateTable(
                "dbo.Child",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GuardianFirstName = c.String(nullable: false, maxLength: 50),
                        GuardianLastName = c.String(nullable: false, maxLength: 50),
                        GuardianPhNo = c.String(),
                        GuardianEmail = c.String(nullable: false),
                        ChildLastName = c.String(),
                        ChildFirstName = c.String(),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(nullable: false),
                        County = c.String(nullable: false),
                        PostalCode = c.String(),
                        DOB = c.DateTime(nullable: false),
                        SpecialNeeds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        EnrolmentID = c.Int(nullable: false),
                        ID = c.Int(nullable: false),
                        AmountReceived = c.Double(nullable: false),
                        AmountDue = c.Double(nullable: false),
                        DateReceived = c.DateTime(nullable: false),
                        PayeeName = c.String(),
                    })
                .PrimaryKey(t => t.EnrolmentID)
                .ForeignKey("dbo.Enrolment", t => t.EnrolmentID)
                .Index(t => t.EnrolmentID);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InstructorFirstName = c.String(),
                        InstructorLastName = c.String(),
                        InstructorEmail = c.String(),
                        InstructorPhNo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.InstructorActivity",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstructorID, t.ActivityID })
                .ForeignKey("dbo.Instructor", t => t.InstructorID, cascadeDelete: true)
                .ForeignKey("dbo.Activity", t => t.ActivityID, cascadeDelete: true)
                .Index(t => t.InstructorID)
                .Index(t => t.ActivityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.InstructorActivity", "ActivityID", "dbo.Activity");
            DropForeignKey("dbo.InstructorActivity", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.Payment", "EnrolmentID", "dbo.Enrolment");
            DropForeignKey("dbo.Enrolment", "ChildID", "dbo.Child");
            DropForeignKey("dbo.Enrolment", "ActivityID", "dbo.Activity");
            DropForeignKey("dbo.Activity", "ClubID", "dbo.Club");
            DropIndex("dbo.InstructorActivity", new[] { "ActivityID" });
            DropIndex("dbo.InstructorActivity", new[] { "InstructorID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Payment", new[] { "EnrolmentID" });
            DropIndex("dbo.Enrolment", new[] { "ActivityID" });
            DropIndex("dbo.Enrolment", new[] { "ChildID" });
            DropIndex("dbo.Activity", new[] { "ClubID" });
            DropTable("dbo.InstructorActivity");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Instructor");
            DropTable("dbo.Payment");
            DropTable("dbo.Child");
            DropTable("dbo.Enrolment");
            DropTable("dbo.Club");
            DropTable("dbo.Activity");
        }
    }
}
