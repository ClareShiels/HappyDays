namespace HappyDaysOne.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HappyDaysOne.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
        //    protected override void Seed(ApplicationDbContext context)
        //{
            //adding the entity details to the approprite DbSet property and saving the changes to the db
            //entering some child details for initialising the db
            var children = new List<Child>
            {
                new Child { ChildFirstName = "Cora", ChildLastName = "Shiels", GuardianEmail = "clareshiels@gmail.com",
                    GuardianFirstName = "Clare", GuardianLastName = "Shiels", GuardianPhNo = "0871234567",
                    DOB = DateTime.Parse("03-06-2009"), SpecialNeeds = SpecialNeeds.no, AddressLine1 = "1 Prospect Meadows", AddressLine2 = "Rathfarnham", County = "Dublin 16", PostalCode = "D16H7R4"},
                new Child { ChildFirstName = "Noah", ChildLastName = "Cashin", GuardianEmail = "clareshiels@gmail.com",
                    GuardianFirstName = "Clare", GuardianLastName = "Shiels", GuardianPhNo = "0871234567",
                    DOB = DateTime.Parse("06-12-2007"), SpecialNeeds = SpecialNeeds.no, AddressLine1 = "1 Prospect Meadows", AddressLine2 = "Rathfarnham", County = "Dublin 16", PostalCode = "D16H7R4" },

            };

            //seeding the Children DBSet
            //performing a SaveChanges method after each group of entities so as to help eliminate a possible problem
            children.ForEach(c => context.Children.AddOrUpdate(c));
            context.SaveChanges();

            var clubs = new List<Club>
            {
                new Club { ClubName = "St Marys BNS", ContactEmail = "activities@StMarys.com",  ContactFirstName = "Paula",
                    ContactLastName = "Byrne", ContactPhNo = "0871231234", AddressLine1 = "2 Templeogue Rd", AddressLine2 = "Templeogue", County = "Dublin 14", PostalCode = "D14H7R8"  },
                new Club { ClubName = "Loreto Grange Rd", ContactEmail = "activities@Loreto.com",  ContactFirstName = "Jason",
                    ContactLastName = "Dean", ContactPhNo = "0861231231", AddressLine1 = "3 Cedar Ave", AddressLine2 = "Terenure", County = "Dublin 6", PostalCode = "D6H7R5" }
            };

            //seeding the Clubs DBSet
            //performing a SaveChanges method after each group of entities so as to help eliminate a possible problem
            clubs.ForEach(a => context.Clubs.AddOrUpdate(a));
            context.SaveChanges();



            var activities = new List<Activity>
            {
                new Activity { ActivityCourseStartDate = DateTime.Parse("12-06-2017"), ActivityCourseEndDate = DateTime.Parse("11-07-2016"),
                    ActivityType = ActivityType.Course, AgeGroup = AgeGroup.UnderSix, Day = DayOfWeek.Monday, NameOfActivity = "Basketball", ClassTime = DateTime.Parse("14:30"), ClubID = 1
                },
                new Activity { ActivityCourseStartDate = DateTime.Parse("01-06-2017"), ActivityCourseEndDate = DateTime.Parse("10-07-2016"),
                    ActivityType = ActivityType.Course, AgeGroup = AgeGroup.NineToTwelve, Day = DayOfWeek.Tuesday, NameOfActivity = "GAA Football", ClassTime = DateTime.Parse("15:00"), ClubID = 2 }
            };

            activities.ForEach(a => context.Activities.AddOrUpdate(a));
            context.SaveChanges();

            var enrolments = new List<Enrolment>
            {
                new Enrolment { ChildID = children.Single(c => c.ChildLastName == "Shiels").ID,
                    ActivityID = activities.Single(a => a.NameOfActivity == "Basketball").ID, PaymentDue = true, PaymentReceived = false},
                new Enrolment { ChildID = children.Single(c => c.ChildLastName == "Cashin").ID,
                    ActivityID = activities.Single(a => a.NameOfActivity == "GAA Football").ID, PaymentDue = false, PaymentReceived = true},
                new Enrolment { ChildID = children.Single(c => c.ChildLastName == "Shiels").ID,
                    ActivityID = activities.Single(a => a.NameOfActivity == "GAA Football").ID, PaymentDue = true, PaymentReceived = false},
                new Models.Enrolment { ChildID = children.Single(c => c.ChildLastName == "Cashin").ID,
                    ActivityID = activities.Single(a => a.NameOfActivity == "Basketball").ID, PaymentDue = false, PaymentReceived = true}
            };

            foreach (Enrolment e in enrolments)
            {
                var enrolmentInDataBase = context.Enrolments.Where(
                    c => c.Child.ID == e.Child.ID &&
                         c.Activity.ID == e.Activity.ID).SingleOrDefault();
                if (enrolmentInDataBase == null)
                {
                    context.Enrolments.AddOrUpdate(e);
                }
            }

            var instructors = new List<Instructor>
            {
                new Instructor { InstructorEmail = "cc@bbb.com", InstructorFirstName = "Coco", InstructorLastName = "Belle", InstructorPhNo = "0872342343" },
                new Instructor { InstructorEmail = "dd@ccc.com", InstructorFirstName = "David", InstructorLastName = "Gray", InstructorPhNo = "0871231231" }
            };

            instructors.ForEach(i => context.Instructors.AddOrUpdate(i));
            context.SaveChanges();


            var payments = new List<Payment>
            {
                new Payment {EnrolmentID = 1,
                DateReceived = DateTime.Parse("05-03-2016"), AmountDue = 80.00, AmountReceived = 80.00, PayeeName = "Clarissa" },
                new Payment {EnrolmentID = 3, DateReceived = DateTime.Parse("02-02-2016"), AmountDue = 120.00, AmountReceived = 120.00, PayeeName = "Jemima" },
                new Payment {EnrolmentID = 2, DateReceived = DateTime.Parse("12-06-2016"), AmountDue = 100.00, AmountReceived = 100.00, PayeeName = "Tre" }
            };

            payments.ForEach(p => context.Payments.AddOrUpdate(p));
            context.SaveChanges();

        }
    }
    //  This method will be called after migrating to the latest version.

    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
    //  to avoid creating duplicate seed data. E.g.
    //
    //    context.People.AddOrUpdate(
    //      p => p.FullName,
    //      new Person { FullName = "Andrew Peters" },
    //      new Person { FullName = "Brice Lambson" },
    //      new Person { FullName = "Rowan Miller" }
    //    );
    //
}
    
