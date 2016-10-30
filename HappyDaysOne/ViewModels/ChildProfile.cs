using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDaysOne.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using HappyDaysOne.Controllers;
using HappyDaysOne.Migrations;
using HappyDaysOne.DAL;

namespace HappyDaysOne.ViewModels
{
    class ChildProfile
    {
        public IEnumerable<ApplicationIdentity> Users { get; set; }
        public IEnumerable<Child> Children { get; set; }
        public IEnumerable<Enrolment> Enrolments { get; set; }
        
    }
}
