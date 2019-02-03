using HamroDokan.Models;
using System;
using System.Collections.Generic;
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
    }
}