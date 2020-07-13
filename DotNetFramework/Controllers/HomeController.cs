using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetFramework.Models;

namespace DotNetFramework.Controllers
{
    public class HomeController : Controller
    {
        private AlertService alertService;
        public ActionResult Index()
        {
            alertService = new AlertService();
            List<AlertModel> lm = new List<AlertModel>();
            
            var alertdict = alertService.GetDataExtension();
            foreach (var alertval in alertdict.Values)
            {
                AlertModel am = new AlertModel();
                am.Category = alertval["Alert_Category"];
                lm.Add(am);
            }

            return View(lm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}