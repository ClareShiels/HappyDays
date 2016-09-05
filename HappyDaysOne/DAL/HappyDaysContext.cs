using HappyDaysOne.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace HappyDaysOne.DAL
{
    public class ApplicationDbContext : DbContext
    {
        //name of connection string being passed into the db context class constructor
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
        }
        //each dbset property correlates to a table, or entity set in the db, each entity is a row in the entity set/table 
        public DbSet<Child> Children { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        //public DbSet<>
        
    }
}