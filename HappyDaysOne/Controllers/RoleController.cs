﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using HappyDaysOne.DAL;
using HappyDaysOne.Models;
using System.Security.Claims;

namespace HappyDaysOne.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        
        //method to check if the user is admin or not

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
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
        // GET:All Roles - if the logged in user is admin then i can get all the role names using the applicationDbContext
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        //create a new role
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index","Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        //creating a new role
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");

            }
        }

 }
