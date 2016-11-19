using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyDaysOne.Models;
using HappyDaysOne.DAL;
using HappyDaysOne.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HappyDaysOne.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;
            
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<TopActivity> data = from activity in db.Activities
                                           group activity by activity.AgeGroup into activityGroupByAge
                                           select new TopActivity()
                                           {
                                               AgeGroup = activityGroupByAge.Key,
                                               ActivityCount = activityGroupByAge.Count()
                                           };
            return View(data.ToList());
        }

        //decommented to try solve login issues

        //[Authorize(Roles = "Child's Guardian, Admin")]
        public ActionResult CurrentIndex()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return View(db.Children.ToList().Where(c => c.User.Id == currentUser.Id));
        }

        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> AllEnrolments()
        {
            return View(await db.Enrolments.ToListAsync());
        }

        [Authorize]
        public new ActionResult Profile()
        {
            // Instantiate the ASP.NET Identity system
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            // Get the current logged in User and look up the user in ASP.NET Identity
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var currentUserRole = currentUser.GetType();
            // Recover the profile information about the logged in user
            if (currentUserRole.Name == "Child's Guardian")
                ViewBag.Email = currentUser.Email;
            ViewBag.UserName = currentUser.UserName;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Happy Days Designs - 1 Prospect Meadows, Rathfarnham, Dublin 16, Ireland";

            return View();
        }
    }
}