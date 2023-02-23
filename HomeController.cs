using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VR.Controllers;
using VR.Models;

namespace VR.Controllers
{
    public class HomeController : Controller
    {
        public DbCustomers db = new DbCustomers();
        public ActionResult Index()
        {
            return View(db.GetCustomers());
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