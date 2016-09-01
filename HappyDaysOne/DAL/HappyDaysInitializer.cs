using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HappyDaysOne.Models;

namespace HappyDaysOne.DAL
{
    public class HappyDaysInitializer : System.Data.Entity.DropCreateDatabaseAlways<HappyDaysContext>
    {
        protected override void Seed(HappyDaysContext context)
        {
            //adding the entity details to the approprite DbSet property and saving the changes to the db
            //entering some child details for initialising the db
            var children = new List<Child>
            {
                new Child { ChildFirstName = "Cora", ChildLastName = "Shiels", GuardianEmail = "clareshiels@gmail.com",
                    GuardianFirstName = "Clare", GuardianLastName = "Shiels", GuardianPhNo = "0871234567",
                    DOB = DateTime.Parse("27-06-2009"), SpecialNeeds = SpecialNeeds.no,   },
                new Child { ChildFirstName = "Noah", ChildLastName = "Shiels", GuardianEmail = "clareshiels@gmail.com",
                    GuardianFirstName = "Clare", GuardianLastName = "Shiels", GuardianPhNo = "0871234567",
                    DOB = DateTime.Parse("06-12-2007"), SpecialNeeds = SpecialNeeds.no,  },

            };

            //performing a SaveChanges method after each group of entities so as to help source a problem should it arise
            children.ForEach(c => context.Children.Add(c));
            context.SaveChanges();

            var clubs = new List<Club>
            {
                new Club { ClubName = "St Marys BNS", ContactEmail = "activities@StMarys.com",  ContactFirstName = "Paula",
                    ContactLastName = "Byrne", ContactPhNo = "0871231234",   },
                new Club { ClubName = "Loreto Grange Rd", ContactEmail = "activities@Loreto.com",  ContactFirstName = "Jason",
                    ContactLastName = "Dean", ContactPhNo = "0861231231", }
            };

            clubs.ForEach(a => context.Clubs.Add(a));
            context.SaveChanges();



            var activities = new List<Activity>
            {
                new Activity { ActivityCourseStartDate = DateTime.Parse("12-06-2017"), ActivityCourseEndDate = DateTime.Parse("13-07-2016"),
                    ActivityType = ActivityType.Course, AgeGroup = AgeGroup.UnderSix, Day = DayOfWeek.Monday, NameOfActivity = "Basketball" },
                new Activity { ActivityCourseStartDate = DateTime.Parse("13-06-2017"), ActivityCourseEndDate = DateTime.Parse("14-07-2016"),
                    ActivityType = ActivityType.Course, AgeGroup = AgeGroup.NineToTwelve, Day = DayOfWeek.Tuesday, NameOfActivity = "GAA Football" }
            };

            activities.ForEach(a => context.Activities.Add(a));
            context.SaveChanges();

            var enrolments = new List<Enrolment>
            {
                new Enrolment { ChildID = 1, ActivityID = 1, PaymentDue = true, PaymentReceived = false, },
                new Enrolment { ChildID = 1, ActivityID = 2, PaymentDue = false, PaymentReceived = true, },
                new Enrolment { ChildID = 2, ActivityID = 1, PaymentDue = true, PaymentReceived = false, }
            };

            enrolments.ForEach(e => context.Enrolments.Add(e));
            context.SaveChanges();

            var addresses = new List<Address>
            {
                new Address { AddressLine1 = "1 Prospect Meadows", AddressLine2 = "Stocking Lane", Area = "Rathfarnham",},
                new Address { AddressLine1 = "8 Watermill Grove", AddressLine2 = "Old Bawn" ,Area = "Tallaght", }
            };

            addresses.ForEach(a => context.Addresses.Add(a));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { InstructorEmail = "cc@bbb.com", InstructorFirstName = "Coco", InstructorLastName = "Belle", InstructorPhNo = "0872342343", },
                new Instructor { InstructorEmail = "dd@ccc.com", InstructorFirstName = "David", InstructorLastName = "Gray", InstructorPhNo = "0871231231", }
            };

            instructors.ForEach(i => context.Instructors.Add(i));
            context.SaveChanges();

            var payments = new List<Payment>
            {
                new Payment {EnrolmentID = 1, DateReceived = DateTime.Parse("15-03-2016"), AmountDue = 80.00, AmountReceived = 80.00, }
            };

            payments.ForEach(p => context.Payments.Add(p));
            context.SaveChanges();
            //TO DO TOMORROW 23.8.16 ENTER LOTS OF D
        }
    }
}