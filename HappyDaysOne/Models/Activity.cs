using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyDaysOne.Models
{
    public enum AgeGroup
    {
        UnderSix, SixToNine, NineToTwelve
    }

    public enum ActivityType
    {
        DropIn, Course
    }


    public class Activity
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Activity")]
        public string NameOfActivity { get; set; }

        public AgeGroup AgeGroup { get; set; }

        public ActivityType ActivityType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of First Class in Course")]
        public DateTime ActivityCourseStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Last Class in Course")]
        public DateTime ActivityCourseEndDate { get; set; }

        public DayOfWeek Day { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime ClassTime { get; set; }

        //foreign key from club
        [ForeignKey("Club")]
        public int ClubID { get; set; }

        //Navigation Property 
        //implementing a 1:m relationship between  activity and  instructor
        public virtual ICollection<Instructor> Instructors { get; set; }

        //implementing a 1:m relationship between activity and enrolments
        public virtual ICollection<Enrolment> Enrolments { get; set; }
        //implementing a m:1 relationship between activities and activity centre
        public virtual Club Club { get; set; }

    }
}