using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using HappyDaysOne.DAL;
using HappyDaysOne.Models;

namespace HappyDaysOne.Controllers
{
  
    
    public class ChildrenController : Controller
    {
        private HappyDaysOne.Models.ApplicationDbContext db = new HappyDaysOne.Models.ApplicationDbContext();

        // GET: Children sorted either by lastname or DOB
        //trying to remove async to get sorting working 17/10
        [Authorize(Roles = "Club Manager, Admin")]
        public ActionResult Index(string sortOrder, string searchString)
        {
            //viewbag variables used to allow the view to configure the column heading hyperlinks with appropriate query string values
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DOBSort = sortOrder == "DOB" ? "date_desc" : "DOB";
            var children = from c in db.Children
                           select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                children = children.Where(c => c.ChildLastName.ToUpper().Contains(searchString.ToUpper()) ||
                                               c.ChildFirstName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    children = children.OrderByDescending(c => c.ChildLastName);
                    break;
                    case "DOB":
                    children = children.OrderBy(c => c.DOB);
                    break;
                case "date_desc":
                    children = children.OrderByDescending(c => c.DOB);
                    break;
                default:
                    children = children.OrderBy(c => c.ChildLastName);
                    break;
            }
            return View(children.ToList());
        }



        // GET: Children/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = await db.Children.FindAsync(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // GET: Children/Create
        [Authorize(Roles = "Child's Guardian")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Child's Guardian, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ChildFirstName,ChildLastName,FirstName,LastName,GuardianPhNo,GuardianEmail,DOB,SpecialNeeds,AddressLine1,AddressLine2,County,PostalCode,PermissionToLeave")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Children.Add(child);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(child);
        }

        // GET: Children/Edit/5
        [Authorize(Roles = "Child's Guardian, Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = await db.Children.FindAsync(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Child's Guardian, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,LastName,GuardianPhNo,GuardianEmail,ChildLastName,ChildFirstName,DOB,SpecialNeeds,AddressLine1, AddressLine2, County, PostalCode, PermissionToLeave")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Entry(child).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(child);
        }

        // GET: Children/Delete/5
        [Authorize(Roles = "Child's Guardian, Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = await db.Children.FindAsync(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Child child = await db.Children.FindAsync(id);
            db.Children.Remove(child);
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
