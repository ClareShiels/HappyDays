namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
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
                .ForeignKey("dbo.Clubs", t => t.ClubID, cascadeDelete: true)
                .Index(t => t.ClubID);
            
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        ContactLastName = c.String(nullable: false, maxLength: 50),
                        ContactPhNo = c.String(),
                        ContactEmail = c.String(nullable: false),
                        ClubName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChildID = c.Int(nullable: false),
                        ClubID = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        Area = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Children", t => t.ChildID, cascadeDelete: true)
                .ForeignKey("dbo.Clubs", t => t.ClubID, cascadeDelete: true)
                .Index(t => t.ChildID)
                .Index(t => t.ClubID);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GuardianFirstName = c.String(nullable: false, maxLength: 50),
                        GuardianLastName = c.String(nullable: false, maxLength: 50),
                        GuardianPhNo = c.String(),
                        GuardianEmail = c.String(nullable: false),
                        ChildLastName = c.String(),
                        ChildFirstName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        SpecialNeeds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enrolments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentReceived = c.Boolean(nullable: false),
                        PaymentDue = c.Boolean(nullable: false),
                        ChildID = c.Int(nullable: false),
                        ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activities", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Children", t => t.ChildID, cascadeDelete: true)
                .Index(t => t.ChildID)
                .Index(t => t.ActivityID);
            
            CreateTable(
                "dbo.Payments",
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
                .ForeignKey("dbo.Enrolments", t => t.EnrolmentID)
                .Index(t => t.EnrolmentID);
            
            CreateTable(
                "dbo.Instructors",
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
                "dbo.InstructorActivities",
                c => new
                    {
                        Instructor_ID = c.Int(nullable: false),
                        Activity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_ID, t.Activity_ID })
                .ForeignKey("dbo.Instructors", t => t.Instructor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ID, cascadeDelete: true)
                .Index(t => t.Instructor_ID)
                .Index(t => t.Activity_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.InstructorActivities", "Activity_ID", "dbo.Activities");
            DropForeignKey("dbo.InstructorActivities", "Instructor_ID", "dbo.Instructors");
            DropForeignKey("dbo.Activities", "ClubID", "dbo.Clubs");
            DropForeignKey("dbo.Addresses", "ClubID", "dbo.Clubs");
            DropForeignKey("dbo.Addresses", "ChildID", "dbo.Children");
            DropForeignKey("dbo.Payments", "EnrolmentID", "dbo.Enrolments");
            DropForeignKey("dbo.Enrolments", "ChildID", "dbo.Children");
            DropForeignKey("dbo.Enrolments", "ActivityID", "dbo.Activities");
            DropIndex("dbo.InstructorActivities", new[] { "Activity_ID" });
            DropIndex("dbo.InstructorActivities", new[] { "Instructor_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Payments", new[] { "EnrolmentID" });
            DropIndex("dbo.Enrolments", new[] { "ActivityID" });
            DropIndex("dbo.Enrolments", new[] { "ChildID" });
            DropIndex("dbo.Addresses", new[] { "ClubID" });
            DropIndex("dbo.Addresses", new[] { "ChildID" });
            DropIndex("dbo.Activities", new[] { "ClubID" });
            DropTable("dbo.InstructorActivities");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Instructors");
            DropTable("dbo.Payments");
            DropTable("dbo.Enrolments");
            DropTable("dbo.Children");
            DropTable("dbo.Addresses");
            DropTable("dbo.Clubs");
            DropTable("dbo.Activities");
        }
    }
}
