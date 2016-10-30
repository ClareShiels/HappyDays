using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HappyDaysOne.DAL;
using HappyDaysOne.Models;
using HappyDaysOne.ViewModels;

namespace HappyDaysOne.Controllers
{
    public class ActivitiesController : Controller
    {
        private HappyDaysOne.Models.ApplicationDbContext db = new HappyDaysOne.Models.ApplicationDbContext();


        //WORKING ON GETTING THE CLUB MANAGERS PAGE TO RETURN A LIST OF ACTIVITIES IN THEIR CLUB
        // GET: Clubs
        public /*async Task*/ActionResult Index(int? clubsID, int? id)
        {
            var viewModel = new ClubsData();
            viewModel.Activities = db.Activities
                                     .Include(c => c.Club)
                                     .Include(c => c.Instructors)
                                     .Include(c => c.Enrolments)
                                     .OrderBy(c => c.NameOfActivity);
            //if we have a clubID we can now fill activities to the view model ClubsData activities table
            if (clubsID != null)
            {
                ViewBag.ClubID = clubsID.Value;
                viewModel.Activities = viewModel.Clubs
                                                    .Where(c => c.ID == id.Value)
                                                    .Single().Activities;
            }

            //decommenting sun 30/10 to try and sort out viewmodel

            ////if we have an activity id we can now fill viewmodel.children with a list of its enrolments
            //if (id != null)
            //{
            //    ViewBag.id = id.Value;
            //    viewModel.Enrolments = viewModel.Children
            //                                            .Where(e => e.ActivityID == id)

            //                                            .Where(e => e.)
            //                                            .Single().;

            //}
            return View(viewModel);
        }

        //just decommented sun 30th oct to try get index data on above action to give a view

        //// GET: Activities
        //public async Task<ActionResult> Index()
        //{
        //    var activities = db.Activities.Include(a => a.Club);
        //    return View(await activities.ToListAsync());
        //}

        // GET: Activity Names - activity name only, use in dropdown list for Activity
        public ActionResult AllActivities()
        {
            return View(db.Activities.ToList().OrderBy(a => a.NameOfActivity));
        }

        // GET: Activities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = await db.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        [Authorize(Roles = "Club manager, Admin")]
        // GET: Activities/Create
        public ActionResult Create()
        {
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "ContactFirstName");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Club manager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NameOfActivity,AgeGroup,ActivityType,ActivityCourseStartDate,ActivityCourseEndDate,Day,ClassTime,ClubName")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "ContactFirstName", activity.ClubID);
            return View(activity);
        }

        // GET: Activities/Edit/5
        [Authorize(Roles = "Club manager, Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = await db.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "ContactFirstName", activity.ClubID);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "Club manager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,NameOfActivity,AgeGroup,ActivityType,ActivityCourseStartDate,ActivityCourseEndDate,Day,ClassTime,ClubID")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClubID = new SelectList(db.Clubs, "ID", "ContactFirstName", activity.ClubID);
            return View(activity);
        }

        // GET: Activities/Delete/5
        [Authorize(Roles = "Club manager, Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = await db.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [Authorize(Roles = "Club manager, Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Activity activity = await db.Activities.FindAsync(id);
            db.Activities.Remove(activity);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
