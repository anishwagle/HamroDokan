using HamroDokan.Models;
using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;


namespace HamroDokan.Controllers
{
    public class SearchController : Controller
    {
        ShoppingStoreEntities storeDB = new ShoppingStoreEntities();
 
        // GET: Search
        public ActionResult Index()
        {
            return View(storeDB.Items.ToList());
        }
        [HttpPost]
        public ActionResult Text(string searching)
        {
            ViewBag.MyString = searching;
            return View(storeDB.Items.Where(x => x.Keyword1.Contains(searching) || searching == null).ToList());
        }
        [HttpPost]
        public ActionResult Image(HttpPostedFileBase file,string result="")
        {
           
            
            if (file!=null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg")
                    {
                        var psi = new ProcessStartInfo();
                        psi.FileName = @"C:\Users\Anish\AppData\Local\Programs\Python\Python37-32\python.exe";

                        var script = @"C:\Users\Anish\Documents\git-hub\HamroDokan\HamroDokan\Content\ImageClassificationWithRandomForest\main.py";
                        var image = file.FileName;
                        psi.Arguments = $"\"{script}\" \"{image}\"";
                        psi.UseShellExecute = false;
                        psi.CreateNoWindow = true;
                        psi.RedirectStandardOutput = true;
                        psi.RedirectStandardError = true;


                        var errors = "";

                        using (var process = Process.Start(psi))
                        {
                            errors = process.StandardError.ReadToEnd();
                            result = process.StandardOutput.ReadToEnd();
                        }

                     
                    }
                    

                }

            }
            string itm = "";
            //ViewBag.MyString = result;
            if (result.Trim()==("Pant"))
            { itm = "Pant"; }
            if (result.Trim() == ("Tshirt"))
            {
                itm = "Tshirt";
            }
            if (result.Trim() == ("Mobile"))
            {
                itm = "Mobile";
            }

            return View(storeDB.Items.Where(x=>x.Keyword1.Equals(itm)).ToList());

        }
        
    }
}