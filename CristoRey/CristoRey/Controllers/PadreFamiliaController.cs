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
    public class PadreFamiliaController : Controller
    {

        private BDColegio db = new BDColegio();

        // GET: PadreFamilia
        public ActionResult Index()
        {
            var pADRE_FAMILIA = db.PADRE_FAMILIA.Include(p => p.DISTRITO);
            return View(pADRE_FAMILIA.ToList());
        }

        [HttpPost]
        public ActionResult Index(string buscar)
        {
            List<PADRE_FAMILIA> padres;
            if (!String.IsNullOrEmpty(buscar))
            {
                var index = buscar.IndexOf(',');
                var dni = buscar.Substring(0, index);
                if (db.IsAllDigits(dni))
                {
                    if (dni.Length == 8)
                    {
                        if (db.PADRE_FAMILIA.Any(x => x.dni_paf.StartsWith(dni)))
                        {
                            padres = db.PADRE_FAMILIA.Where(x => x.dni_paf.StartsWith(dni)).ToList();
                        }
                        else
                        {
                            padres = db.PADRE_FAMILIA.ToList();
                        }
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('El DNI no tiene 8 dígitos');</script>";
                        padres = db.PADRE_FAMILIA.ToList();
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('DNI incorrecto');</script>";
                    padres = db.PADRE_FAMILIA.ToList();
                }
            }
            else
            {
                padres = db.PADRE_FAMILIA.ToList();
            }

            return View(padres);
        }

        public JsonResult getPadres(string term)
        {
            List<string> padres;
            padres = db.PADRE_FAMILIA.Where(x => x.dni_paf.StartsWith(term)).Select(a => a.dni_paf + ", " + a.nom_paf + " " + a.app_paf + " " + a.apm_paf).ToList();
            return Json(padres, JsonRequestBehavior.AllowGet);
        }



        // GET: PadreFamilia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PADRE_FAMILIA pADRE_FAMILIA = db.PADRE_FAMILIA.Find(id);
            if (pADRE_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pADRE_FAMILIA);
        }

        // GET: PadreFamilia/Create
        public ActionResult Create()
        {
            ViewBag.Deps = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep");
            ViewBag.Provs = new SelectList("");
            ViewBag.Dist = new SelectList("");
            return View();
        }

        public JsonResult getProvincias(string Id)
        {
            if (Id != "")
            {
                getDistritos("");
                var provincias = db.PROVINCIA.ToList().Where(p => p.cod_dep == int.Parse(Id));
                return Json(new SelectList(provincias, "cod_pro", "nom_pro"));
            }
            else
            {
                return Json("");
            }
        }

        public JsonResult getDistritos(string Id)
        {
            if (Id != "")
            {
                var distritos = db.DISTRITO.ToList().Where(p => p.cod_pro == int.Parse(Id));
                return Json(new SelectList(distritos, "cod_dis", "nom_dis"));
            }
            else
            {
                return Json("");
            }
        }

        // POST: PadreFamilia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_paf,nom_paf,app_paf,apm_paf,dni_paf,fna_paf,sex_paf,cor_paf,tel_paf,dir_paf,apo_paf,tel_apo,cod_dis")] PADRE_FAMILIA pADRE_FAMILIA)
        {

            if (ModelState.IsValid)
            {

                int dep, pro, dis;

                if (Request.Form["DEPARTAMENTO"].ToString() != "")
                {
                    dep = int.Parse(Request.Form["DEPARTAMENTO"]);
                    if (Request.Form["PROVINCIA"].ToString() != "")
                    {
                        pro = int.Parse(Request.Form["PROVINCIA"]);
                        if (Request.Form["DISTRITO"].ToString() != "")
                        {
                            dis = int.Parse(Request.Form["DISTRITO"]);
                            pADRE_FAMILIA.cod_dis = dis;
                            if (!db.PADRE_FAMILIA.Any(a => a.dni_paf.Equals(pADRE_FAMILIA.dni_paf)))
                            {
                                if (!(pADRE_FAMILIA.fna_paf > DateTime.Now))
                                {
                                    db.PADRE_FAMILIA.Add(pADRE_FAMILIA);
                                    db.SaveChanges();
                                    return RedirectToAction("Index");
                                }
                                else
                                {
                                    ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                    ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                    ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                    TempData["msg"] = "<script>alert('Fecha incorrecta');</script>";
                                    return View(pADRE_FAMILIA);
                                }
                            }
                            else
                            {
                                ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                TempData["msg"] = "<script>alert('Dos personas no pueden tener el mismo DNI');</script>";
                                return View(pADRE_FAMILIA);
                            }
                        }
                        else
                        {

                            ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                            ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                            ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis");
                            return View(pADRE_FAMILIA);
                        }
                    }
                    else
                    {
                        ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                        ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro");
                        ViewData["DISTRITO"] = new SelectList("");
                        return View(pADRE_FAMILIA);
                    }
                }


                else
                {
                    ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep");
                    ViewData["PROVINCIA"] = new SelectList("");
                    ViewData["DISTRITO"] = new SelectList("");
                    return View(pADRE_FAMILIA);
                }
            }

            return View(pADRE_FAMILIA);
        }

        // GET: PadreFamilia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PADRE_FAMILIA pADRE_FAMILIA = db.PADRE_FAMILIA.Find(id);
            if (pADRE_FAMILIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_dis = new SelectList(db.DISTRITO, "cod_dis", "nom_dis", pADRE_FAMILIA.cod_dis);
            return View(pADRE_FAMILIA);
        }

        // POST: PadreFamilia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_paf,nom_paf,app_paf,apm_paf,dni_paf,fna_paf,sex_paf,cor_paf,tel_paf,dir_paf,apo_paf,tel_apo,cod_dis")] PADRE_FAMILIA pADRE_FAMILIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pADRE_FAMILIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pADRE_FAMILIA);
        }

        // GET: PadreFamilia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PADRE_FAMILIA pADRE_FAMILIA = db.PADRE_FAMILIA.Find(id);
            if (pADRE_FAMILIA == null)
            {
                return HttpNotFound();
            }
            return View(pADRE_FAMILIA);
        }

        // POST: PadreFamilia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PADRE_FAMILIA pADRE_FAMILIA = db.PADRE_FAMILIA.Find(id);
            db.PADRE_FAMILIA.Remove(pADRE_FAMILIA);
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
