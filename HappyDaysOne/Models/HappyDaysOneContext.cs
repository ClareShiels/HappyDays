﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HappyDaysOne.Models
{
    public class HappyDaysOneContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HappyDaysOneContext() : base("name=HappyDaysOneContext")
        {
        }

        public System.Data.Entity.DbSet<HappyDaysOne.Models.Enrolment> Enrolments { get; set; }

        public System.Data.Entity.DbSet<HappyDaysOne.Models.Activity> Activities { get; set; }

        public System.Data.Entity.DbSet<HappyDaysOne.Models.Child> Children { get; set; }

        public System.Data.Entity.DbSet<HappyDaysOne.Models.Payment> Payments { get; set; }
    }
}
