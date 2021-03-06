﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyDaysOne.Models
{
    public class Enrolment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Select if Payment has been Received" )]
        public Boolean PaymentReceived { get; set; }
        public Boolean PaymentDue { get; set; }

        //foreign key from child entity
        [ForeignKey("Child")]
        public int ChildID { get; set; }

        //foreign key from activity entity
        [ForeignKey("Activity")]
        public int ActivityID { get; set; }

        //Navigation Properties:
        //implementing a m - 1 relationship between enrolment and activity
        public virtual Activity Activity { get; set; }
        //implementing a m:1 relationship between enrolment and child
        public virtual Child Child { get; set; }

        //navigation property to payment implementing a m:1 relationship
        public virtual Payment Payment { get; set; }
    }
}