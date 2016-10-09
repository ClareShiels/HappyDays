using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyDaysOne.Models
{
    public class Club
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "Club Administrator's First Name")]

        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Club Administrator's Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
        public string ContactPhNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }
        public string ClubName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string County { get; set; }
        public string PostalCode { get; set; }

        
        //foreign key for ApplicationUser
        //[ForeignKey("UserID")]
        //public string UserID { get; set; }

        //Navigation Properties: 

        //implementing a 1:m relationship between activity centre and instructors
        public virtual ICollection<Instructor> Instructors { get; set; }
        //navigation property implementing a 1:m relationship between activity centre and activities
        public virtual ICollection<Activity> Activities { get; set; }

        //navigation property implementing a 1:1 relationship between Club Manager and Application User
        
       //public virtual ApplicationUser User { get; set; }
    }
}