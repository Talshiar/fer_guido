using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleMapsApi.StaticMaps;
using Baza;

namespace Guido.Controllers
{
    public class HomeController : Controller
    {
        private GuidoEntities db = new GuidoEntities();

        public ActionResult Index()
        {
            var city = db.City.Include(c => c.State);
            return View(city.ToList());
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