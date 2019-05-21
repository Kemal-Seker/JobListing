using JobListing.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using JobListing.UI.ViewModels;

namespace JobListing.UI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminManagementController : Controller
    {
        JobListingUserEntities userdb = new JobListingUserEntities();
        public ActionResult Index()
        {
            var allusers = userdb.AspNetUsers.ToList();
            var users = allusers.Where(x => x.AspNetRoles.Select(role => role.Name).Contains("User")).ToList();
            var userVM = users.Select(user => new UserViewModel { Username = user.UserName,Phone=user.PhoneNumber,Email=user.Email, Roles = string.Join(",", user.AspNetRoles.Select(role => role.Name)) }).ToList();

            var admins = allusers.Where(x => x.AspNetRoles.Select(role => role.Name).Contains("Admin")).ToList();
            var adminsVM = admins.Select(user => new UserViewModel { Username = user.UserName,Phone=user.PhoneNumber,Email=user.Email,Roles = string.Join(",", user.AspNetRoles.Select(role => role.Name)) }).ToList();
            var model = new UserwithRoleViewModel { Users = userVM, Admins = adminsVM };

            return View(model);
        }
    }
}