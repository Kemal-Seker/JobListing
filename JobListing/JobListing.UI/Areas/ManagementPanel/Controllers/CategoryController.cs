using JobListing.BLL;
using JobListing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Areas.ManagementPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        
        CategoryService cs = new CategoryService();
        public ActionResult Index()
        {           
            var catList = cs.GetAll().ToList();
            return View(catList);
        }

        public ActionResult New()
        {
            return View("CategoryForm");
        }

        public ActionResult Detail(int id)
        {
            var detailCategory = cs.FindBy(x => x.CategoryId==id).SingleOrDefault();
            return View("DetailForm",detailCategory);
        }

        public ActionResult Save(Category category)
        {
            if (category.CategoryId==0)
            {
                cs.Insert(category);
            }
            else
            {
                cs.Update(category);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var editCategory = cs.FindBy(x => x.CategoryId == id).SingleOrDefault();
            return View("CategoryForm", editCategory);
        }

        public ActionResult Delete(int id)
        {
            var deleteCategory = cs.FindBy(x => x.CategoryId==id).SingleOrDefault();
            cs.Remove(deleteCategory);
            return RedirectToAction("Index");
        }
    }
}