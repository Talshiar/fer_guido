using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleMapsApi.StaticMaps;
using Baza;
using System.Data.SqlClient;

namespace Guido.Controllers
{
    public class HomeController : Controller
    {
        private GuidoEntities db = new GuidoEntities();

        public ActionResult Index()
        {
            dynamic mymodel = new ViewModel();
            mymodel.City = db.City.Include(c => c.State);
            mymodel.Place = db.Place.Include(v => v.City);
            mymodel.TypeOfPlace = db.TypeOfPlace;
            return View(mymodel);
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

        //Za racunanje ruta
        [HttpGet]
        public ActionResult GetRoute()
        {
            var routePoints = new
            {
                RouteId = new LinkedList<int>(),
                Position = new LinkedList<int>(),
                Longitude = new LinkedList<double>(),
                Latitude = new LinkedList<double>(),
                Name = new LinkedList<string>(),
                Address = new LinkedList<string>(),
                Description = new LinkedList<string>()
            };
            var routes =
                from o in db.RoutePoint
                select new
                {
                    idR = o.IdRoute,
                    pos = (int)o.PositionInRoute,
                    lng = o.Place.longitude,
                    lat = o.Place.latitude,
                    nm = o.Place.name,
                    adr = o.Place.adress,
                    dsc = o.Place.dscrb
                };
            foreach (var n in routes)
            {
                routePoints.RouteId.AddLast(n.idR);
                routePoints.Position.AddLast(n.pos);
                routePoints.Longitude.AddLast(n.lng);
                routePoints.Latitude.AddLast(n.lat);
                routePoints.Name.AddLast(n.nm);
                routePoints.Address.AddLast(n.adr);
                routePoints.Description.AddLast(n.dsc);

            }
            return Json(routePoints, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetJSONData()
        {
               
            // Create a JSON document setting the string array to the count of the rows
            var Places = new {
                Name = new LinkedList<string>(),
                Address = new LinkedList<string>(),
                Description = new LinkedList<string>(),
                PlaceType = new LinkedList<int>(),
                Latitude = new LinkedList<double>(),
                Longitude = new LinkedList<double>()
            };

            var allPlaces =
               from p in db.Place
               select new
               {
                   name = p.name,
                   adrs = p.adress,
                   lng = p.longitude,
                   lat = p.latitude,
                   descr = p.dscrb,
                   type = p.typeOfPlace,
               };

            
            foreach (var n in allPlaces)
            {
                Places.Name.AddLast(n.name);
                Places.Address.AddLast(n.adrs);
                Places.Description.AddLast(n.descr);
                Places.Latitude.AddLast(n.lat);
                Places.Longitude.AddLast(n.lng);
                Places.PlaceType.AddLast(n.type);
                
            }
            

            // Return the JSON document to the view
            return Json(Places);

        }
    }
}