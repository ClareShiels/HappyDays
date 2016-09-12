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
        [Display(Name = "First Name")]

        public string ContactFirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string ContactLastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return ContactLastName + ", " + ContactFirstName;
            }
        }
        public string ContactPhNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }
        public string ClubName { get; set; }

        //foreign key from application user
        //[ForeignKey("UserID")]
        //[Required]
        //public string UserID { get; set; }

        //foreign key from address entity
        //[ForeignKey("Address")]
        //public int AddressID { get; set; }

        //Navigation Properties: 

        //implementing a 1:1 relationship between club and application user
        //[ForeignKey("UserID")]
        //public virtual ApplicationUser User { get; set; }
        //implementing a 1:m relationship between club and address
        public virtual ICollection<Address> Addresses { get; set; }
        //implementing a 1:m relationship between activity centre and instructors
        //public virtual ICollection<Instructor> Instructors { get; set; }
        //navigation property implementing a 1:m relationship between activity centre and activities
        public virtual ICollection<Activity> Activities { get; set; }

    }
}