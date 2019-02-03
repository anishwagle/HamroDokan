using HamroDokan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HamroDokan.Controllers
{
    public class SearchController : Controller
    {
        ShoppingStoreEntities storeDB = new ShoppingStoreEntities();
        // GET: Search
        public ActionResult Index(string searching)
        {


            return View(storeDB.Items.Where(x => x.Keyword1.Contains(searching)||searching==null).ToList());
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var path = "";
            if (file!=null)
            {
                if(file.ContentLength>0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() ==".jpg")
                    {
                        path = Path.Combine(Server.MapPath(@"..\..\Content\Images\Unknown"), file.FileName);
                        file.SaveAs(path);

                    }

                }
            }
            return View();
        }
    }
}