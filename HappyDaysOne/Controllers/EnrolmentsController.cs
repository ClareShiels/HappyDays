using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HappyDaysOne.Models;

namespace HappyDaysOne.Controllers
{
    public class EnrolmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enrolments
        public async Task<ActionResult> Index()
        {
            var enrolments = db.Enrolments.Include(e => e.Activity).Include(e => e.Child).Include(e => e.Payment);
            return View(await enrolments.ToListAsync());
        }

        // GET: Enrolments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = await db.Enrolments.FindAsync(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            return View(enrolment);
        }

        // GET: Enrolments/Create
        public ActionResult Create()
        {
            ViewBag.ActivityID = new SelectList(db.Activities, "ID", "NameOfActivity");
            ViewBag.ChildID = new SelectList(db.Children, "ID", "FirstName");
            ViewBag.ID = new SelectList(db.Payments, "EnrolmentID", "PayeeName");
            return View();
        }

        // POST: Enrolments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,PaymentReceived,PaymentDue,ChildID,ActivityID")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                db.Enrolments.Add(enrolment);
                await db.SaveChangesAsync();
                //db.Enrolments
                return RedirectToAction("Index");
            }

            ViewBag.ActivityID = new SelectList(db.Activities, "ID", "NameOfActivity", enrolment.ActivityID);
            ViewBag.ChildID = new SelectList(db.Children, "ID", "FirstName", enrolment.ChildID);
            ViewBag.ID = new SelectList(db.Payments, "EnrolmentID", "PayeeName", enrolment.ID);
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = await db.Enrolments.FindAsync(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "ID", "NameOfActivity", enrolment.ActivityID);
            ViewBag.ChildID = new SelectList(db.Children, "ID", "FirstName", enrolment.ChildID);
            ViewBag.ID = new SelectList(db.Payments, "EnrolmentID", "PayeeName", enrolment.ID);
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,PaymentReceived,PaymentDue,ChildID,ActivityID")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrolment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "ID", "NameOfActivity", enrolment.ActivityID);
            ViewBag.ChildID = new SelectList(db.Children, "ID", "FirstName", enrolment.ChildID);
            ViewBag.ID = new SelectList(db.Payments, "EnrolmentID", "PayeeName", enrolment.ID);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = await db.Enrolments.FindAsync(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            return View(enrolment);
        }

        // POST: Enrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Enrolment enrolment = await db.Enrolments.FindAsync(id);
            db.Enrolments.Remove(enrolment);
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
