using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyDaysOne.Models;
using HappyDaysOne.DAL;
using HappyDaysOne.ViewModels;

namespace HappyDaysOne.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}