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
    public class GradoController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: Grado
        public ActionResult Index()
        {
            var gRADO = db.GRADO.Include(g => g.AULA);
            return View(gRADO.ToList());
        }
        

        // GET: Grado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRADO gRADO = db.GRADO.Find(id);
            if (gRADO == null)
            {
                return HttpNotFound();
            }
            return View(gRADO);
        }

        // GET: Grado/Create
        public ActionResult Create()
        {
            ViewBag.cod_aula = new SelectList(db.AULA, "cod_aula", "des_ubi");
            return View();
        }

        // POST: Grado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_gra,des_gra,niv_gra,sec_gra,cod_aula")] GRADO gRADO)
        {
            if (ModelState.IsValid)
            {
                db.GRADO.Add(gRADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_aula = new SelectList(db.AULA, "cod_aula", "des_ubi", gRADO.cod_aula);
            return View(gRADO);
        }

        // GET: Grado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRADO gRADO = db.GRADO.Find(id);
            if (gRADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_aula = new SelectList(db.AULA, "cod_aula", "des_ubi", gRADO.cod_aula);
            return View(gRADO);
        }

        // POST: Grado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_gra,des_gra,niv_gra,sec_gra,cod_aula")] GRADO gRADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gRADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_aula = new SelectList(db.AULA, "cod_aula", "des_ubi", gRADO.cod_aula);
            return View(gRADO);
        }

        // GET: Grado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GRADO gRADO = db.GRADO.Find(id);
            if (gRADO == null)
            {
                return HttpNotFound();
            }
            return View(gRADO);
        }

        // POST: Grado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GRADO gRADO = db.GRADO.Find(id);
            db.GRADO.Remove(gRADO);
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
