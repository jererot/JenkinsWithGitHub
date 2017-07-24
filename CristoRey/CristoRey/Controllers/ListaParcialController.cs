using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CristoRey.Models;

namespace CristoRey.Controllers
{
    public class ListaParcialController : Controller
    {
        BDColegio db = new BDColegio();

        // GET: ListaParcial
        public ActionResult Index(int? grado)
        {
            var lista = from a in db.ALUMNO join m in db.MATRICULA on a.cod_alum equals m.cod_alum where m.cod_gra == grado select a;
            return View(lista);
        }

        public JsonResult getAlumnos(int? grado)
        {
            var lista = from a in db.ALUMNO join m in db.MATRICULA on a.cod_alum equals m.cod_alum where m.cod_gra == grado select a.cod_alum;
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}