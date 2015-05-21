using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoogleMapsApi.StaticMaps;
using Baza;
using System.Data.SqlClient;

namespace Guido.Controllers
{
    public class PlacesController : Controller
    {
        private GuidoEntities db = new GuidoEntities();

        // GET: Places
        public ActionResult Index()
        {
            var place = db.Place.Include(p => p.City);
            return View(place.ToList());
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Place.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        [HttpGet]
        public ActionResult CreateRoute(int? id)
        {
            if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var newRoute = new
            {
                PlaceId = new LinkedList<int>(),
                PlaceType = new LinkedList<int>(),
                Longitude = new LinkedList<double>(),
                Latitude = new LinkedList<double>(),
                Name = new LinkedList<string>(),
                Address = new LinkedList<string>(),
                Description = new LinkedList<string>()
            };

            var places = from p in db.Place
                         select new
                         {
                             idP = p.ID,
                             pType = p.typeOfPlace,
                             descrb = p.dscrb,
                             lng = p.longitude,
                             lat = p.latitude,
                             pName = p.name,
                             pAdr = p.adress
                         };
            foreach (var item in places)
            {
                newRoute.PlaceId.AddLast(item.idP);
                newRoute.PlaceType.AddLast(item.pType);
                newRoute.Description.AddLast(item.descrb);
                newRoute.Longitude.AddLast(item.lng);
                newRoute.Latitude.AddLast(item.lat);
                newRoute.Name.AddLast(item.pName);
                newRoute.Address.AddLast(item.pAdr);
            }

            return Json(newRoute, JsonRequestBehavior.AllowGet);
        }
    }
}
