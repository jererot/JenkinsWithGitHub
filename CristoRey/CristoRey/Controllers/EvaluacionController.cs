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
    public class EvaluacionController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: Evaluacion
        public ActionResult Index()
        {
            var eVALUACION = db.EVALUACION.Include(e => e.CURSO).Include(e => e.MATRICULA).Include(e => e.PERIODO);
            return View(eVALUACION.ToList());
        }

        // GET: Evaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVALUACION eVALUACION = db.EVALUACION.Find(id);
            if (eVALUACION == null)
            {
                return HttpNotFound();
            }
            return View(eVALUACION);
        }

        // GET: Evaluacion/Create
        public ActionResult Create()
        {
            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur");
            ViewBag.cod_mat = new SelectList(db.MATRICULA, "cod_mat", "cod_mat");
            ViewBag.cod_per = new SelectList(db.PERIODO, "cod_per", "des_per");
            return View();
        }

        // POST: Evaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_per,cod_mat,n1p_eva,n2p_eva,n1e_eva,n2e_eva,pro_eva,cod_cur")] EVALUACION eVALUACION)
        {
            if (ModelState.IsValid)
            {
                db.EVALUACION.Add(eVALUACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur", eVALUACION.cod_cur);
            ViewBag.cod_mat = new SelectList(db.MATRICULA, "cod_mat", "cod_mat", eVALUACION.cod_mat);
            ViewBag.cod_per = new SelectList(db.PERIODO, "cod_per", "des_per", eVALUACION.cod_per);
            return View(eVALUACION);
        }

        // GET: Evaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVALUACION eVALUACION = db.EVALUACION.Find(id);
            if (eVALUACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur", eVALUACION.cod_cur);
            ViewBag.cod_mat = new SelectList(db.MATRICULA, "cod_mat", "cod_mat", eVALUACION.cod_mat);
            ViewBag.cod_per = new SelectList(db.PERIODO, "cod_per", "des_per", eVALUACION.cod_per);
            return View(eVALUACION);
        }

        // POST: Evaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_per,cod_mat,n1p_eva,n2p_eva,n1e_eva,n2e_eva,pro_eva,cod_cur")] EVALUACION eVALUACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVALUACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_cur = new SelectList(db.CURSO, "cod_cur", "nom_cur", eVALUACION.cod_cur);
            ViewBag.cod_mat = new SelectList(db.MATRICULA, "cod_mat", "cod_mat", eVALUACION.cod_mat);
            ViewBag.cod_per = new SelectList(db.PERIODO, "cod_per", "des_per", eVALUACION.cod_per);
            return View(eVALUACION);
        }

        // GET: Evaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVALUACION eVALUACION = db.EVALUACION.Find(id);
            if (eVALUACION == null)
            {
                return HttpNotFound();
            }
            return View(eVALUACION);
        }

        // POST: Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVALUACION eVALUACION = db.EVALUACION.Find(id);
            db.EVALUACION.Remove(eVALUACION);
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
