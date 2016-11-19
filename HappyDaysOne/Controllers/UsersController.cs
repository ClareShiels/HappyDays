using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HappyDaysOne.DAL;
using HappyDaysOne.Models;
using HappyDaysOne.ViewModels;
using System.Security.Claims;

namespace HappyDaysOne.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //checking if the user logged in is admin

        // GET: Users  
        //Checking if User is logged into the system if not then display message "Not logged in"
        //If user is authenticated, check the logged in user's role
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        //bool isAdminUser = false;

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                //default displayMenu is no
                ViewBag.displayMenu = "No";
                //check if user is Admin using method described above which returns a boolean
                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                //decommenting 29/10
                //check if user is Child's Guardian
                else if (User.IsInRole("Child's Guardian"))
                {
                    ViewBag.displayMenu = "Child's Guardian";
                    ViewBag.UserID = User.Identity.GetUserId();
                    //load UserID into child's guardian table 
                    var UserID = User.Identity.GetUserId();
                    ViewBag.ChildID = db.Children.Where(c => c.UserID == UserID);
                }
                ////check if user is Club Manager
                else if (User.IsInRole("Club Manager"))
                {
                    ViewBag.displayMenu = "Club Manager";
                    ViewBag.UserID = User.Identity.GetUserId();
                    //add current user id into variable UserID
                    var UserID = User.Identity.GetUserId();
                    ViewBag.ClubID = db.Clubs.Where(c => c.UserID == UserID);
                }
                return View();
            }

            else
            {
                ViewBag.Name = "Not logged IN";
            }
            return View();
        }
    }
}
