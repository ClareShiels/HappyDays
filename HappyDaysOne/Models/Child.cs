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

        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Guardian's Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Guardian's Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public string GuardianPhNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string GuardianEmail { get; set; }
        public string ChildLastName { get; set; }
        public string ChildFirstName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string County { get; set; }
        public string PostalCode { get; set; }
        public Boolean PermissionToLeave { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Child's Date Of Birth")]
        public DateTime DOB { get; set; }
        //public DateTime RegistrationDate{get;set;}
        public SpecialNeeds SpecialNeeds { get; set; }

        //navigation properties implementing a 1:m relationship between Child and Enrolments
        public virtual ICollection<Enrolment> Enrolments { get; set; }

    }
}