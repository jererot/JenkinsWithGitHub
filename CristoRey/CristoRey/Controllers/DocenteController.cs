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
    public class DocenteController : Controller
    {
        private BDColegio db = new BDColegio();

        // GET: Docente
        public ActionResult Index(string buscar)
        {
            var dOCENTE = db.DOCENTE.Include(d => d.DISTRITO).Include(d => d.DOCENTE_FULLTIME).Include(d => d.DOCENTE_PARTTIME);

            if (!String.IsNullOrEmpty(buscar))
            {
                dOCENTE = dOCENTE.Where(x => x.dni_doc.Contains(buscar));
            }

            return View(dOCENTE.ToList());
        }

        // GET: Docente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCENTE dOCENTE = db.DOCENTE.Find(id);
            if (dOCENTE == null)
            {
                return HttpNotFound();
            }
            return View(dOCENTE);
        }

        // GET: Docente/Create
        public ActionResult Create()
        {
            //ViewBag.cod_dis = new SelectList(db.DISTRITO, "cod_dis", "nom_dis");
            ViewBag.Deps = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep");
            ViewBag.Provs = new SelectList(db.PROVINCIA, "cod_pro", "nom_pro");
            ViewBag.Dist = new SelectList(db.DISTRITO, "cod_dis", "nom_dis");
            ViewBag.cod_doc = new SelectList(db.DOCENTE_FULLTIME, "cod_doc", "cod_doc");
            ViewBag.cod_doc = new SelectList(db.DOCENTE_PARTTIME, "cod_doc", "cod_doc");
            return View();
        }

        public JsonResult getProvincias(int Id)
        {
            var provincias = db.PROVINCIA.ToList().Where(p => p.cod_dep == Id);
            return Json(new SelectList(provincias, "cod_pro", "nom_pro"));
        }

        public JsonResult getDistritos(int Id)
        {
            var distritos = db.DISTRITO.ToList().Where(p => p.cod_pro == Id);
            return Json(new SelectList(distritos, "cod_dis", "nom_dis"));
        }

        // POST: Docente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_doc,nom_doc,app_doc,apm_doc,dni_doc,sex_doc,fna_doc,cor_doc,tel_doc,dir_doc,tip_doc,cod_dis")] DOCENTE dOCENTE)
        {


            if (ModelState.IsValid)
            {
                dOCENTE.cod_dis = int.Parse(Request.Form["DISTRITO"]);
                if (!db.DOCENTE.Any(a => a.dni_doc.Equals(dOCENTE.dni_doc)))
                {
                    db.DOCENTE.Add(dOCENTE);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = "<script>alert('Dos personas no pueden tener el mismo DNI');</script>";
                    return RedirectToAction("Create");
                }
            }

            //ViewBag.cod_dis = new SelectList(db.DISTRITO, "cod_dis", "nom_dis", dOCENTE.cod_dis);
            ViewBag.cod_doc = new SelectList(db.DOCENTE_FULLTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            ViewBag.cod_doc = new SelectList(db.DOCENTE_PARTTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            return View(dOCENTE);
            //if (ModelState.IsValid)
            //{
            //    dOCENTE.cod_dis = int.Parse(Request.Form["DISTRITO"]);
            //    db.DOCENTE.Add(dOCENTE);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            ////ViewBag.cod_dis = new SelectList(db.DISTRITO, "cod_dis", "nom_dis", dOCENTE.cod_dis);
            //ViewBag.cod_doc = new SelectList(db.DOCENTE_FULLTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            //ViewBag.cod_doc = new SelectList(db.DOCENTE_PARTTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            //return View(dOCENTE);
        }

        // GET: Docente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCENTE dOCENTE = db.DOCENTE.Find(id);
            if (dOCENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_dis = new SelectList(db.DISTRITO, "cod_dis", "nom_dis", dOCENTE.cod_dis);
            ViewBag.cod_doc = new SelectList(db.DOCENTE_FULLTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            ViewBag.cod_doc = new SelectList(db.DOCENTE_PARTTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            return View(dOCENTE);
        }

        // POST: Docente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_doc,nom_doc,app_doc,apm_doc,dni_doc,sex_doc,fna_doc,cor_doc,tel_doc,dir_doc,tip_doc,cod_dis")] DOCENTE dOCENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_dis = new SelectList(db.DISTRITO, "cod_dis", "nom_dis", dOCENTE.cod_dis);
            ViewBag.cod_doc = new SelectList(db.DOCENTE_FULLTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            ViewBag.cod_doc = new SelectList(db.DOCENTE_PARTTIME, "cod_doc", "cod_doc", dOCENTE.cod_doc);
            return View(dOCENTE);
        }

        // GET: Docente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCENTE dOCENTE = db.DOCENTE.Find(id);
            if (dOCENTE == null)
            {
                return HttpNotFound();
            }
            return View(dOCENTE);
        }

        // POST: Docente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCENTE dOCENTE = db.DOCENTE.Find(id);
            db.DOCENTE.Remove(dOCENTE);
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
