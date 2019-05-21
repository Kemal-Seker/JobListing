using JobListing.BLL;
using JobListing.UI.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Controllers
{
    [AllowAnonymous]
    public class JobsController : Controller
    {
        CityService cityserv = new CityService();
        CategoryService cs = new CategoryService();
        CompanyService comserv = new CompanyService();
        JobService js = new JobService();
        public ActionResult List(int page = 1)
        {
            var model = js.GetAll().ToList();
            ViewData["CityList"] = cityserv.GetAll().ToList();
            ViewData["CategoryList"] = cs.GetAll().ToList();
            return View(model.OrderBy(x=>x.JobId).ToPagedList(page,4));
        }

        public ActionResult Detail(int id)
        {
            var model = js.FindBy(x => x.Company.CityId == id).ToList();
            return View("Detail", model);
        }


        public ActionResult JobDetail(int id)
        {
            var model = new JobViewModel()
            {
                companies = comserv.GetAll().ToList(),
                job = js.FindBy(x => x.JobId == id).SingleOrDefault()
            };

            return View("JobDetail", model);
        }
    }
}