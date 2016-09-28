namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.InstructorActivity", name: "Instructor_ID", newName: "InstructorID");
            RenameColumn(table: "dbo.InstructorActivity", name: "Activity_ID", newName: "ActivityID");
            RenameIndex(table: "dbo.InstructorActivity", name: "IX_Instructor_ID", newName: "IX_InstructorID");
            RenameIndex(table: "dbo.InstructorActivity", name: "IX_Activity_ID", newName: "IX_ActivityID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.InstructorActivity", name: "IX_ActivityID", newName: "IX_Activity_ID");
            RenameIndex(table: "dbo.InstructorActivity", name: "IX_InstructorID", newName: "IX_Instructor_ID");
            RenameColumn(table: "dbo.InstructorActivity", name: "ActivityID", newName: "Activity_ID");
            RenameColumn(table: "dbo.InstructorActivity", name: "InstructorID", newName: "Instructor_ID");
        }
    }
}
