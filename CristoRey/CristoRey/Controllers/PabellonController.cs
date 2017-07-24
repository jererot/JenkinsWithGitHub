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
    public class PabellonController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: Pabellon
        public ActionResult Index()
        {
            return View(db.PABELLON.ToList());
        }

        // GET: Pabellon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PABELLON pABELLON = db.PABELLON.Find(id);
            if (pABELLON == null)
            {
                return HttpNotFound();
            }
            return View(pABELLON);
        }

        // GET: Pabellon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pabellon/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_pab,nrp_pab,nra_pab,nap_pab")] PABELLON pABELLON)
        {
            if (ModelState.IsValid)
            {
                db.PABELLON.Add(pABELLON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pABELLON);
        }

        // GET: Pabellon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PABELLON pABELLON = db.PABELLON.Find(id);
            if (pABELLON == null)
            {
                return HttpNotFound();
            }
            return View(pABELLON);
        }

        // POST: Pabellon/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_pab,nrp_pab,nra_pab,nap_pab")] PABELLON pABELLON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pABELLON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pABELLON);
        }

        // GET: Pabellon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PABELLON pABELLON = db.PABELLON.Find(id);
            if (pABELLON == null)
            {
                return HttpNotFound();
            }
            return View(pABELLON);
        }

        // POST: Pabellon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PABELLON pABELLON = db.PABELLON.Find(id);
            db.PABELLON.Remove(pABELLON);
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
