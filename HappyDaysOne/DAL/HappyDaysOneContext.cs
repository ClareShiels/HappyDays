using HappyDaysOne.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HappyDaysOne.DAL
{
    public class HappyDaysOneContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Payment> Payments { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Instructor>()
                .HasMany(c => c.Activities).WithMany(i => i.Instructors)
                .Map(t => t.MapLeftKey("InstructorID")
                    .MapRightKey("ActivityID")
                    .ToTable("InstructorActivity"));

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}
