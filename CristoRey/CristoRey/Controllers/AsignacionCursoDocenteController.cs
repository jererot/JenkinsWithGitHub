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
    public class AsignacionCursoDocenteController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: AsignacionCursoDocente
        public ActionResult Index()
        {
            var aSIGNACION_CURSO_DOCENTE = db.ASIGNACION_CURSO_DOCENTE.Include(a => a.CURSO).Include(a => a.DOCENTE);
            return View(aSIGNACION_CURSO_DOCENTE.ToList());
        }

        // GET: AsignacionCursoDocente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACION_CURSO_DOCENTE aSIGNACION_CURSO_DOCENTE = db.ASIGNACION_CURSO_DOCENTE.Find(id);
            if (aSIGNACION_CURSO_DOCENTE == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACION_CURSO_DOCENTE);
        }

        // GET: AsignacionCursoDocente/Create
        public ActionResult Create()
        {
            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur");
            ViewBag.cod_doc = new SelectList(db.DOCENTE, "cod_doc", "nom_doc");
            return View();
        }

        // POST: AsignacionCursoDocente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_acd,cod_doc,cod_cur")] ASIGNACION_CURSO_DOCENTE aSIGNACION_CURSO_DOCENTE)
        {
            if (ModelState.IsValid)
            {
                db.ASIGNACION_CURSO_DOCENTE.Add(aSIGNACION_CURSO_DOCENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur", aSIGNACION_CURSO_DOCENTE.cod_cur);
            ViewBag.cod_doc = new SelectList(db.DOCENTE, "cod_doc", "nom_doc", aSIGNACION_CURSO_DOCENTE.cod_doc);
            return View(aSIGNACION_CURSO_DOCENTE);
        }

        // GET: AsignacionCursoDocente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACION_CURSO_DOCENTE aSIGNACION_CURSO_DOCENTE = db.ASIGNACION_CURSO_DOCENTE.Find(id);
            if (aSIGNACION_CURSO_DOCENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur", aSIGNACION_CURSO_DOCENTE.cod_cur);
            ViewBag.cod_doc = new SelectList(db.DOCENTE, "cod_doc", "nom_doc", aSIGNACION_CURSO_DOCENTE.cod_doc);
            return View(aSIGNACION_CURSO_DOCENTE);
        }

        // POST: AsignacionCursoDocente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_acd,cod_doc,cod_cur")] ASIGNACION_CURSO_DOCENTE aSIGNACION_CURSO_DOCENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSIGNACION_CURSO_DOCENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur", aSIGNACION_CURSO_DOCENTE.cod_cur);
            ViewBag.cod_doc = new SelectList(db.DOCENTE, "cod_doc", "nom_doc", aSIGNACION_CURSO_DOCENTE.cod_doc);
            return View(aSIGNACION_CURSO_DOCENTE);
        }

        // GET: AsignacionCursoDocente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACION_CURSO_DOCENTE aSIGNACION_CURSO_DOCENTE = db.ASIGNACION_CURSO_DOCENTE.Find(id);
            if (aSIGNACION_CURSO_DOCENTE == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACION_CURSO_DOCENTE);
        }

        // POST: AsignacionCursoDocente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASIGNACION_CURSO_DOCENTE aSIGNACION_CURSO_DOCENTE = db.ASIGNACION_CURSO_DOCENTE.Find(id);
            db.ASIGNACION_CURSO_DOCENTE.Remove(aSIGNACION_CURSO_DOCENTE);
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
