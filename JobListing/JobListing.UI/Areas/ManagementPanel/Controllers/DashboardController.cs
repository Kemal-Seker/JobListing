using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Areas.ManagementPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}