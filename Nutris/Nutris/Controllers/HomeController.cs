using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nutris.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult IndexNutri()
        {
            return View();
        }

        [Authorize]
        public ActionResult IndexCliente()
        {
            return View();
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