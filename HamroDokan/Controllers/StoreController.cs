using HamroDokan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HamroDokan.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            var category = new List<Category>
            {
                new Category{Name="Mobile"},
                new Category{Name="Pant"},
                new Category{Name="T-shirt"},
            };
            return View(category);
        }
        public ActionResult Browse(string category)
        {
            var categoryModel = new Category { Name = category };
            return View(categoryModel);
        }
        public ActionResult Details(int id)
        {
            var iteam = new Item { Title = "Item" + id };
            return View(iteam);
        }
    }
}