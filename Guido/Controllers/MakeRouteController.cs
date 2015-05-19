using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baza;

namespace Guido.Controllers
{
    public class MakeRouteController : Controller
    {
        private GuidoEntities db = new GuidoEntities();

        // GET: /MakeRoute/
        public ActionResult Index()
        {
            var routepoint = db.RoutePoint.Include(r => r.Place).Include(r => r.Route);
            return View(routepoint.ToList());
        }

        // GET: /MakeRoute/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutePoint routepoint = db.RoutePoint.Find(id);
            if (routepoint == null)
            {
                return HttpNotFound();
            }
            return View(routepoint);
        }

        // GET: /MakeRoute/Create
        public ActionResult Create()
        {
            ViewBag.IdPlace = new SelectList(db.Place, "ID", "dscrb");
            ViewBag.IdRoute = new SelectList(db.Route, "ID", "typOfRoute");
            return View();
        }

        // POST: /MakeRoute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdRoutePoint,IdPlace,IdRoute,PositionInRoute")] RoutePoint routepoint)
        {
            if (ModelState.IsValid)
            {
                db.RoutePoint.Add(routepoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPlace = new SelectList(db.Place, "ID", "dscrb", routepoint.IdPlace);
            ViewBag.IdRoute = new SelectList(db.Route, "ID", "typOfRoute", routepoint.IdRoute);
            return View(routepoint);
        }

        // GET: /MakeRoute/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutePoint routepoint = db.RoutePoint.Find(id);
            if (routepoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPlace = new SelectList(db.Place, "ID", "dscrb", routepoint.IdPlace);
            ViewBag.IdRoute = new SelectList(db.Route, "ID", "typOfRoute", routepoint.IdRoute);
            return View(routepoint);
        }

        // POST: /MakeRoute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdRoutePoint,IdPlace,IdRoute,PositionInRoute")] RoutePoint routepoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routepoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPlace = new SelectList(db.Place, "ID", "dscrb", routepoint.IdPlace);
            ViewBag.IdRoute = new SelectList(db.Route, "ID", "typOfRoute", routepoint.IdRoute);
            return View(routepoint);
        }

        // GET: /MakeRoute/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoutePoint routepoint = db.RoutePoint.Find(id);
            if (routepoint == null)
            {
                return HttpNotFound();
            }
            return View(routepoint);
        }

        // POST: /MakeRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoutePoint routepoint = db.RoutePoint.Find(id);
            db.RoutePoint.Remove(routepoint);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
