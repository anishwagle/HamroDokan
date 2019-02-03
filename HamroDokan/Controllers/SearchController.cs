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
        public string xyz;
        // GET: Search
        public ActionResult Index(string searching)
        {


            return View(storeDB.Items.Where(x => x.Keyword1.Contains(searching)||searching==null).ToList());
        }
        [HttpPost]
        public ActionResult Image(HttpPostedFileBase file)
        {
            
            
            if (file!=null)
            {
                if(file.ContentLength>0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() ==".jpg")
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
                        var results = "";

                        using (var process = Process.Start(psi))
                        {
                            errors = process.StandardError.ReadToEnd();
                            results = process.StandardOutput.ReadToEnd();
                        }
                         xyz=results;
                        //xyz = errors;

                    }

                }
            }
            ViewBag.MyString = xyz;
            return View();
        }
    }
}