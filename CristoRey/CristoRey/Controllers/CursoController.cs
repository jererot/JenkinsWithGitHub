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
    public class CursoController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: Curso
        public ActionResult Index()
        {
            var cURSO = db.CURSO.Include(c => c.AREA).Include(c => c.GRADO);
            return View(cURSO.ToList());
        }

        // GET: Curso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            ViewBag.cod_are = new SelectList(db.AREA, "cod_are", "des_are");
            ViewBag.cod_gra = new SelectList(db.GRADO, "cod_gra", "des_gra");
            return View();
        }

        // POST: Curso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_cur,nom_cur,hin_cur,hfi_cur,cod_are,cod_gra")] CURSO cURSO)
        {
            if (ModelState.IsValid)
            {
                db.CURSO.Add(cURSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_are = new SelectList(db.AREA, "cod_are", "des_are", cURSO.cod_are);
            ViewBag.cod_gra = new SelectList(db.GRADO, "cod_gra", "des_gra", cURSO.cod_gra);
            return View(cURSO);
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_are = new SelectList(db.AREA, "cod_are", "des_are", cURSO.cod_are);
            ViewBag.cod_gra = new SelectList(db.GRADO, "cod_gra", "des_gra", cURSO.cod_gra);
            return View(cURSO);
        }

        // POST: Curso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_cur,nom_cur,hin_cur,hfi_cur,cod_are,cod_gra")] CURSO cURSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cURSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_are = new SelectList(db.AREA, "cod_are", "des_are", cURSO.cod_are);
            ViewBag.cod_gra = new SelectList(db.GRADO, "cod_gra", "des_gra", cURSO.cod_gra);
            return View(cURSO);
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSO cURSO = db.CURSO.Find(id);
            if (cURSO == null)
            {
                return HttpNotFound();
            }
            return View(cURSO);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CURSO cURSO = db.CURSO.Find(id);
            db.CURSO.Remove(cURSO);
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
