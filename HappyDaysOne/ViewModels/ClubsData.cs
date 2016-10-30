using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HappyDaysOne.Models;

namespace HappyDaysOne.ViewModels
{
    public class ClubsData
    {
        public IEnumerable<Child> Children { get; set; }
        public IEnumerable<Enrolment> Enrolments { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<Club> Clubs { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        //public IEnumerable<ApplicationIdentity> users { get; set; }

        //public Club Club { get; set; }


        
    }
}
