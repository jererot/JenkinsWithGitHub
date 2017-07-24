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
    public class AulaController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: Aula
        public ActionResult Index()
        {
            var aULA = db.AULA.Include(a => a.PABELLON);
            return View(aULA.ToList());
        }

        // GET: Aula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AULA aULA = db.AULA.Find(id);
            if (aULA == null)
            {
                return HttpNotFound();
            }
            return View(aULA);
        }

        // GET: Aula/Create
        public ActionResult Create()
        {
            ViewBag.cod_pab = new SelectList(db.PABELLON, "cod_pab", "cod_pab");
            return View();
        }

        // POST: Aula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_aula,cod_pab,des_ubi,nca_aul")] AULA aULA)
        {
            if (ModelState.IsValid)
            {
                db.AULA.Add(aULA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_pab = new SelectList(db.PABELLON, "cod_pab", "cod_pab", aULA.cod_pab);
            return View(aULA);
        }

        // GET: Aula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AULA aULA = db.AULA.Find(id);
            if (aULA == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_pab = new SelectList(db.PABELLON, "cod_pab", "cod_pab", aULA.cod_pab);
            return View(aULA);
        }

        // POST: Aula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_aula,cod_pab,des_ubi,nca_aul")] AULA aULA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aULA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_pab = new SelectList(db.PABELLON, "cod_pab", "cod_pab", aULA.cod_pab);
            return View(aULA);
        }

        // GET: Aula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AULA aULA = db.AULA.Find(id);
            if (aULA == null)
            {
                return HttpNotFound();
            }
            return View(aULA);
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AULA aULA = db.AULA.Find(id);
            db.AULA.Remove(aULA);
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
