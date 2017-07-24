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
    public class AlumnoController : Controller
    {

        private BDColegio db = new BDColegio();

        // GET: Alumno
        public ActionResult Index()
        {
            ViewBag.Title2 = "Mantenimiento de Alumnos";

            var aLUMNO = db.ALUMNO.Include(a => a.DISTRITO).Include(a => a.PADRE_FAMILIA);
            return View(aLUMNO.ToList());
        }


        [HttpPost]
        public ActionResult Index(string buscar)
        {

            List<ALUMNO> alumnos;
            if (!String.IsNullOrEmpty(buscar))
            {
                var index = buscar.IndexOf(',');
                var dni = buscar.Substring(0, index);
                if (db.IsAllDigits(dni))
                {
                    if (dni.Length == 8)
                    {
                        if (db.ALUMNO.Any(x => x.dni_alum.StartsWith(dni)))
                        {
                            alumnos = db.ALUMNO.Where(x => x.dni_alum.StartsWith(dni)).ToList();
                        }
                        else
                        {
                            alumnos = db.ALUMNO.ToList();
                        }
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('El DNI no tiene 8 dígitos');</script>";
                        alumnos = db.ALUMNO.ToList();
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('DNI incorrecto');</script>";
                    alumnos = db.ALUMNO.ToList();
                }
            }
            else
            {
                alumnos = db.ALUMNO.ToList();
            }

            return View(alumnos);
        }


        public JsonResult getAlumnos(string term)
        {
            List<string> alumnos;
            alumnos = db.ALUMNO.Where(x => x.dni_alum.StartsWith(term)).Select(a => a.dni_alum + ", " + a.nom_alum + " " + a.app_alum + " " + a.apm_alum).ToList();
            return Json(alumnos, JsonRequestBehavior.AllowGet);
        }




        // GET: Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO);
        }

        // GET: Alumno/Create
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

        // POST: Alumno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_alum,nom_alum,app_alum,apm_alum,dni_alum,fna_alum,sex_alum,cor_alum,tel_alum,dir_alum,cod_dis,cod_paf")] ALUMNO aLUMNO)
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
                            aLUMNO.cod_dis = dis;
                            if (!db.PADRE_FAMILIA.Any(p => p.dni_paf.Equals(aLUMNO.dni_alum)))
                            {
                                if (!db.ALUMNO.Any(a => a.dni_alum.Equals(aLUMNO.dni_alum)))
                                {
                                    if (Request.Form["buscar"] != "")
                                    {
                                        ViewData["busqueda"] = Request.Form["buscar"].ToString();
                                        var index = Request.Form["buscar"].IndexOf(',');
                                        var dni = Request.Form["buscar"].Substring(0, index);

                                        if (db.IsAllDigits(dni))
                                        {
                                            if (dni.Length == 8)
                                            {
                                                if (db.PADRE_FAMILIA.Any(p => p.dni_paf.Equals(dni)))
                                                {
                                                    if (!(aLUMNO.fna_alum > DateTime.Now))
                                                    {
                                                        aLUMNO.cod_paf =
                                                            db.PADRE_FAMILIA.Where(p => p.dni_paf.Equals(dni))
                                                                .Select(p => p.cod_paf)
                                                                .First();
                                                            
                                                        db.ALUMNO.Add(aLUMNO);
                                                        db.SaveChanges();
                                                        return RedirectToAction("Index");
                                                    }
                                                    else
                                                    {
                                                        ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                                        ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                                        ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                                        TempData["msg"] = "<script>alert('Fecha incorrecta');</script>";
                                                        return View(aLUMNO);
                                                    }
                                                }
                                                else
                                                {
                                                    ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                                    ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                                    ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                                    TempData["msg"] = "<script>alert('El DNI del padre no está registrado');</script>";
                                                    return View(aLUMNO);
                                                }
                                            }
                                            else
                                            {
                                                ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                                ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                                ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                                TempData["msg"] = "<script>alert('El DNI del padre debe tener 8 digitos');</script>";
                                                return View(aLUMNO);
                                            }
                                        }
                                        else
                                        {
                                            ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                            ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                            ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                            TempData["msg"] = "<script>alert('El DNI del padre debe contener sólo números');</script>";
                                            return View(aLUMNO);
                                        }
                                    }
                                    else
                                    {
                                        ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                        ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                        ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                        TempData["msg"] = "<script>alert('El DNI del padre no puede estar en blanco');</script>";
                                        return View(aLUMNO);
                                    }
                                }
                                else
                                {
                                    ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                    ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                    ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                    TempData["msg"] = "<script>alert('Dos personas no pueden tener el mismo DNI');</script>";
                                    return View(aLUMNO);
                                }
                            }
                            else
                            {
                                ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                                ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                                ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis", dis);
                                TempData["msg"] = "<script>alert('Un padre no puede matricularse como alumno');</script>";
                                return View(aLUMNO);
                            }
                        }
                        else
                        {

                            ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                            ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro", pro);
                            ViewData["DISTRITO"] = new SelectList(db.DISTRITO.Where(d => d.cod_pro == pro), "cod_dis", "nom_dis");
                            return View(aLUMNO);
                        }
                    }
                    else
                    {
                        ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep", dep);
                        ViewData["PROVINCIA"] = new SelectList(db.PROVINCIA.Where(d => d.cod_dep == dep), "cod_pro", "nom_pro");
                        ViewData["DISTRITO"] = new SelectList("");
                        return View(aLUMNO);
                    }
                }


                else
                {
                    ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep");
                    ViewData["PROVINCIA"] = new SelectList("");
                    ViewData["DISTRITO"] = new SelectList("");
                    return View(aLUMNO);
                }
            }

            ViewData["DEPARTAMENTO"] = new SelectList(db.DEPARTAMENTO, "cod_dep", "nom_dep");
            ViewData["PROVINCIA"] = new SelectList("");
            ViewData["DISTRITO"] = new SelectList("");
            return View(aLUMNO);
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            
            return View(aLUMNO);
        }

        // POST: Alumno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_alum,nom_alum,app_alum,apm_alum,dni_alum,fna_alum,sex_alum,cor_alum,tel_alum,dir_alum,cod_dis,cod_paf")] ALUMNO aLUMNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUMNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLUMNO);
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            db.ALUMNO.Remove(aLUMNO);
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
