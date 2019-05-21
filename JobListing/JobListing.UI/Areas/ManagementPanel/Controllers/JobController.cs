using JobListing.BLL;
using JobListing.Entities;
using JobListing.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Areas.ManagementPanel.Controllers
{
    [Authorize(Roles ="Admin")]
    public class JobController : Controller
    {
        CompanyService cs = new CompanyService();
        JobService js = new JobService();
        public ActionResult Index()
        {
            var model = js.GetAll().ToList();
            return View(model);
        }

        public ActionResult New()
        {
            var model = new JobViewModel()
            {
                companies = cs.GetAll().ToList(),
            };
            return View("JobForm", model);
        }

        public ActionResult Detail(int id)
        {
            var detailJob = new JobViewModel()
            {
                companies = cs.GetAll().ToList(),
                job = js.FindBy(x=>x.JobId==id).SingleOrDefault()
            };

            return View("DetailForm", detailJob);
        }

        public ActionResult Save(Job job)
        {
            if (job.JobId==0)
            {
                js.Insert(job);
            }
            else
            {
                js.Update(job);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var editJob = new JobViewModel()
            {
                companies = cs.GetAll().ToList(),
                job = js.FindBy(x => x.JobId==id).SingleOrDefault()
            };

            return View("JobForm", editJob);
        }

        public ActionResult Delete(int id)
        {
            var deleteJob = js.FindBy(x => x.JobId == id).SingleOrDefault();
            js.Remove(deleteJob);
            return RedirectToAction("Index");
        }
    }
}