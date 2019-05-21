using JobListing.BLL;
using JobListing.Entities;
using JobListing.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace JobListing.UI.Areas.ManagementPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        CityService cts = new CityService();
        CompanyService cs = new CompanyService();
        public ActionResult Index()
        {
            var companyList = cs.GetAll().ToList();
            return View(companyList);
        }

        public ActionResult Detail(int id)
        {
            var detailCompany = new CompanyViewModel()
            {
                cities = cts.GetAll().ToList(),
                company = cs.FindBy(x => x.CompanyId == id).SingleOrDefault()
            };
            return View("DetailForm", detailCompany);
        }

        public ActionResult New()
        {
            var model = new CompanyViewModel()
            {
                cities = cts.GetAll().ToList(),
            };
            return View("CompanyForm",model);
        }

        public ActionResult Save(Company company)
        {
            if (company.CompanyId == 0)
            {
                if (Request.Files != null && Request.Files.Count == 1)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var content = new byte[file.ContentLength];
                        file.InputStream.Read(content, 0, file.ContentLength);
                        company.Logo = content;
                    }
                }
                cs.Insert(company);
            }
            else
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var content = new byte[file.ContentLength];
                    file.InputStream.Read(content, 0, file.ContentLength);
                    company.Logo = content;
                }
                cs.Update(company);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var editCompany = new CompanyViewModel() {
                cities = cts.GetAll().ToList(),
                company = cs.FindBy(x=>x.CompanyId==id).SingleOrDefault()
            };

            return View("CompanyForm", editCompany);
        }

        public ActionResult Delete(int id)
        {
            var deleteCompany = cs.FindBy(x => x.CompanyId == id).SingleOrDefault();
            cs.Remove(deleteCompany);
            return RedirectToAction("Index");
        }
    }
}