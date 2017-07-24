using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CristoRey.Models;

namespace CristoRey.Controllers
{
    public class AreaController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: Area
        public ActionResult Index()
        {
            return View(db.AREA.ToList());
        }

        // GET: Area/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = db.AREA.Find(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // GET: Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_are,des_are")] AREA aREA)
        {
            if (ModelState.IsValid)
            {
                db.AREA.Add(aREA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aREA);
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = db.AREA.Find(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // POST: Area/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_are,des_are")] AREA aREA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aREA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aREA);
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AREA aREA = db.AREA.Find(id);
            if (aREA == null)
            {
                return HttpNotFound();
            }
            return View(aREA);
        }

        // POST: Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AREA aREA = db.AREA.Find(id);
            db.AREA.Remove(aREA);
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
