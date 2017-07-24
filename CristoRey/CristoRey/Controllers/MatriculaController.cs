using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CristoRey.Models;
using CrystalDecisions.CrystalReports.Engine;






namespace CristoRey.Controllers
{
    public class MatriculaController : Controller
    {

        private BDColegio db = new BDColegio();

        // GET: Matricula
        public ActionResult Index()
        {
            var mATRICULA = db.MATRICULA.Include(m => m.ALUMNO).Include(m => m.GRADO);
            return View(mATRICULA.ToList());
        }

        [HttpPost]
        public ActionResult Index(string buscar)
        {
            List<MATRICULA> alumnos;
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
                            alumnos = db.MATRICULA.Where(x => x.ALUMNO.dni_alum.StartsWith(dni)).ToList();
                        }
                        else
                        {
                            alumnos = db.MATRICULA.ToList();
                        }
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('El DNI no tiene 8 dígitos');</script>";
                        alumnos = db.MATRICULA.ToList();
                    }
                }
                else
                {
                    TempData["msg"] = "<script>alert('DNI incorrecto');</script>";
                    alumnos = db.MATRICULA.ToList();
                }
            }
            else
            {
                alumnos = db.MATRICULA.ToList();
            }

            return View(alumnos);
        }


        public JsonResult getAlumnos(string term)
        {
            List<string> alumnos;
            alumnos = db.ALUMNO.Where(x => x.dni_alum.StartsWith(term)).Select(a => a.dni_alum + ", " + a.nom_alum + " " + a.app_alum + " " + a.apm_alum).ToList();
            return Json(alumnos, JsonRequestBehavior.AllowGet);
        }











        // GET: Matricula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATRICULA mATRICULA = db.MATRICULA.Find(id);
            if (mATRICULA == null)
            {
                return HttpNotFound();
            }
            return View(mATRICULA);
        }

        // GET: Matricula/Create
        public ActionResult Create()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Primaria",
                Value = "P"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Secundaria",
                Value = "S"
            });
            ViewBag.nivel = new SelectList(listItems,"Value","Text");
            ViewBag.grado = new SelectList("");
            return View();
        }

        public JsonResult getGrados(string nivel)
        {
            if (nivel != "")
            {
                var grados = db.GRADO.ToList().Where(g => g.niv_gra == nivel);
                return Json(new SelectList(grados, "cod_gra", "gradoSeccion"));
            }
            else
            {
                return Json("");
            }
        }

        public JsonResult Limite(int? id)
        {
            var limite = (from g in db.GRADO
                          join a in db.AULA on g.cod_aula equals a.cod_aula
                          where g.cod_gra == id
                          select a.nca_aul).First();
            var alumnos = (from a in db.ALUMNO join m in db.MATRICULA on a.cod_alum equals m.cod_alum where m.cod_gra == id select a.cod_alum).Count();
            if (alumnos < limite)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Matricula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_mat,cod_alum,pro_mat,cod_gra")] MATRICULA mATRICULA)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Primaria",
                Value = "P"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Secundaria",
                Value = "S"
            });
            if (ModelState.IsValid)
            {
                string niv ;
                int gra;
                if (Request.Form["buscar"] != "")
                {
                    ViewData["busqueda"] = Request.Form["buscar"].ToString();
                    ViewData["prom"] = Request.Form["pro_mat"].ToString();
                    var index = Request.Form["buscar"].IndexOf(',');
                    string dni;
                    if (index == -1 || index == 0)
                    {
                        dni = Request.Form["buscar"];
                    }
                    else
                    {
                        dni = Request.Form["buscar"].Substring(0, index);
                    }
                    if (db.IsAllDigits(dni))
                    {
                        if (dni.Length == 8)
                        {
                            if (db.ALUMNO.Any(a => a.dni_alum.Equals(dni)))
                            {
                                var codAlu = db.ALUMNO.Where(a => a.dni_alum.Equals(dni)).Select(a => a.cod_alum).First();
                                mATRICULA.cod_alum = codAlu;
                                if (Request.Form["NIVEL"].ToString() != "")
                                {
                                    niv = Request.Form["NIVEL"];
                                    if (Request.Form["GRADO"].ToString() != "")
                                    {
                                        gra = int.Parse(Request.Form["GRADO"]);
                                        mATRICULA.cod_gra = gra;
                                        if (!(db.MATRICULA.Any(x => x.cod_alum == mATRICULA.cod_alum)))
                                        {
                                            var limite = (from g in db.GRADO
                                                          join a in db.AULA on g.cod_aula equals a.cod_aula
                                                          where g.cod_gra == gra
                                                          select a.nca_aul).First();
                                            var alumnos = (from a in db.ALUMNO join m in db.MATRICULA on a.cod_alum equals m.cod_alum where m.cod_gra == gra select a.cod_alum).Count();
                                            if (alumnos < limite)
                                            {
                                                db.MATRICULA.Add(mATRICULA);
                                                db.SaveChanges();
                                                return RedirectToAction("Index");
                                            }
                                            else
                                            {
                                                ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", niv);
                                                ViewData["GRADO"] = new SelectList(db.GRADO.ToList().Where(g => g.niv_gra == niv), "cod_gra", "gradoSeccion");
                                                TempData["msg"] = "<script>alert('No se pueden matricular más alumnos');</script>";
                                                return View(mATRICULA);
                                            }

                                        }
                                        else
                                        {
                                            TempData["msg"] = "<script>alert('El alumno ya se encuentra matriculado');</script>";
                                            ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", niv);
                                            ViewData["GRADO"] = new SelectList(db.GRADO.ToList().Where(g => g.niv_gra == niv), "cod_gra", "gradoSeccion");
                                            return View(mATRICULA);
                                        }
                                    }
                                    else
                                    {
                                        ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", niv);
                                        ViewData["GRADO"] = new SelectList("");
                                        return View(mATRICULA);
                                    }
                                }
                                else
                                {
                                    ViewBag.nivel = new SelectList(listItems, "Value", "Text");
                                    ViewData["GRADO"] = new SelectList("");
                                    return View(mATRICULA);
                                }
                            }
                            else
                            {

                                TempData["msg"] = "<script>alert('El DNI no está registrado');</script>";
                                ViewBag.nivel = new SelectList(listItems, "Value", "Text");
                                ViewData["GRADO"] = new SelectList("");
                                return View(mATRICULA);
                            }
                        }
                        else
                        {
                            if (Request.Form["NIVEL"].ToString() != "")
                            {
                                if (Request.Form["GRADO"].ToString() == "")
                                {
                                    ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", Request.Form["NIVEL"].ToString());
                                    ViewData["GRADO"] = new SelectList("");
                                    TempData["msg"] = "<script>alert('El DNI no tiene 8 dígitos');</script>";
                                    return View(mATRICULA);
                                }
                                else
                                {
                                    ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", Request.Form["NIVEL"].ToString());
                                    ViewData["GRADO"] = new SelectList(db.GRADO.ToList().Where(g => g.cod_gra == int.Parse(Request.Form["GRADO"])), "cod_gra", "gradoSeccion");
                                    TempData["msg"] = "<script>alert('El DNI no tiene 8 dígitos');</script>";
                                    return View(mATRICULA);
                                }
                            }
                            else
                            {
                                ViewBag.nivel = new SelectList(listItems, "Value", "Text");
                                ViewData["GRADO"] = new SelectList("");
                                TempData["msg"] = "<script>alert('El DNI no tiene 8 dígitos');</script>";
                                return View(mATRICULA);
                            }
                        }
                    }
                    else
                    {
                        if (Request.Form["NIVEL"].ToString() != "")
                        {
                            if (Request.Form["GRADO"].ToString() == "")
                            {
                                ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", Request.Form["NIVEL"].ToString());
                                ViewData["GRADO"] = new SelectList("");
                                TempData["msg"] = "<script>alert('DNI incorrecto');</script>";
                                return View(mATRICULA);
                            }
                            else
                            {
                                ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", Request.Form["NIVEL"].ToString());
                                ViewData["GRADO"] = new SelectList(db.GRADO.ToList().Where(g => g.cod_gra == int.Parse(Request.Form["GRADO"])), "cod_gra", "gradoSeccion");
                                TempData["msg"] = "<script>alert('DNI incorrecto');</script>";
                                return View(mATRICULA);
                            }
                        }
                        else
                        {
                            ViewBag.nivel = new SelectList(listItems, "Value", "Text");
                            ViewData["GRADO"] = new SelectList("");
                            TempData["msg"] = "<script>alert('DNI incorrecto');</script>";
                            return View(mATRICULA);
                        }
                    }
                }
                else
                {
                    if (Request.Form["NIVEL"].ToString() != "")
                    {
                        if (Request.Form["GRADO"].ToString() == "")
                        {
                            ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", Request.Form["NIVEL"].ToString());
                            ViewData["GRADO"] = new SelectList("");
                            return View(mATRICULA);
                        }
                        else
                        {
                            ViewData["NIVEL"] = new SelectList(listItems, "Value", "Text", Request.Form["NIVEL"].ToString());
                            ViewData["GRADO"] = new SelectList(db.GRADO.ToList().Where(g => g.cod_gra == int.Parse(Request.Form["GRADO"])), "cod_gra", "gradoSeccion");
                            return View(mATRICULA);
                        }
                    }
                    else
                    {
                        ViewBag.nivel = new SelectList(listItems, "Value", "Text");
                        ViewData["GRADO"] = new SelectList("");
                        return View(mATRICULA);
                    }
                }
            }

            ViewBag.nivel = new SelectList(listItems, "Value", "Text");
            ViewData["GRADO"] = new SelectList("");
            return View(mATRICULA);
        }

        // GET: Matricula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATRICULA mATRICULA = db.MATRICULA.Find(id);
            if (mATRICULA == null)
            {
                return HttpNotFound();
            }
            return View(mATRICULA);
        }

        // POST: Matricula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_mat,cod_alum,pro_mat,cod_gra")] MATRICULA mATRICULA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mATRICULA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mATRICULA);
        }

        // GET: Matricula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATRICULA mATRICULA = db.MATRICULA.Find(id);
            if (mATRICULA == null)
            {
                return HttpNotFound();
            }
            return View(mATRICULA);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MATRICULA mATRICULA = db.MATRICULA.Find(id);
            db.MATRICULA.Remove(mATRICULA);
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


        //public ActionResult ReporteMatricula()
        //{
        //    MATRICULA objRpt = new MATRICULA();

        //    String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
        //    SqlConnection con = new SqlConnection(cnn);

        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("select * from Matriculados", con);
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        adp.Fill(dt);
        //    }
        //    catch (Exception e)
        //    {
        //    }

        //    ReportClass rpth = new ReportClass();
        //    rpth.FileName = Server.MapPath("~/Reporte/ReporteMatriculados.rpt");
        //    rpth.Load();
        //    rpth.SetDataSource(dt);
        //    Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    return File(stream, "application/pdf");
        //}

    }
}
