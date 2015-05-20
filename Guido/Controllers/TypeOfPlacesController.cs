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
    public class TypeOfPlacesController : Controller
    {
        private GuidoEntities db = new GuidoEntities();

        // GET: TypeOfPlaces
        public ActionResult Index()
        {
            //var city = db.City.Include(c => c.State);
            //return View(city.ToList());
            var type = db.TypeOfPlace.Include(c => c.IdTypeOfPlace);
            return View(type.ToList());
            //return View(db.TypeOfPlace.ToList());
        }

        // GET: TypeOfPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfPlace typeOfPlace = db.TypeOfPlace.Find(id);
            if (typeOfPlace == null)
            {
                return HttpNotFound();
            }
            return View(typeOfPlace);
        }

        // GET: TypeOfPlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTypeOfPlace,NameTypeOfPlace")] TypeOfPlace typeOfPlace)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfPlace.Add(typeOfPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfPlace);
        }

        // GET: TypeOfPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfPlace typeOfPlace = db.TypeOfPlace.Find(id);
            if (typeOfPlace == null)
            {
                return HttpNotFound();
            }
            return View(typeOfPlace);
        }

        // POST: TypeOfPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTypeOfPlace,NameTypeOfPlace")] TypeOfPlace typeOfPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfPlace);
        }

        // GET: TypeOfPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfPlace typeOfPlace = db.TypeOfPlace.Find(id);
            if (typeOfPlace == null)
            {
                return HttpNotFound();
            }
            return View(typeOfPlace);
        }

        // POST: TypeOfPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfPlace typeOfPlace = db.TypeOfPlace.Find(id);
            db.TypeOfPlace.Remove(typeOfPlace);
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
