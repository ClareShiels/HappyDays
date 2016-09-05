using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace HappyDaysOne.Models
{
    public enum SpecialNeeds
    {
        yes, no
    }
    public class Child
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [Column("GuardianFirstName")]
        [Display(Name = "Guardian's First Name")]

        public string GuardianFirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string GuardianLastName { get; set; }

        [Display(Name = "Guardian's Full Name")]
        public string FullName
        {
            get
            {
                return GuardianLastName + ", " + GuardianFirstName;
            }
        }
        public string GuardianPhNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string GuardianEmail { get; set; }
        public string ChildLastName { get; set; }
        public string ChildFirstName { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Child's Date Of Birth")]
        public DateTime DOB { get; set; }
        //public DateTime RegistrationDate{get;set;}
        public SpecialNeeds SpecialNeeds { get; set; }

        //foreign key from the address entity 1:m
        //[ForeignKey("Address")]
        //public int AddressID { get; set; }

        //navigation properties implementing a 1:1 relationship between Child and Address
        public virtual ICollection<Address> Addresses { get; set; }

        //navigation properties implementing a 1:m relationship between Child and Enrolments
        public virtual ICollection<Enrolment> Enrolments { get; set; }

    }
}