using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;

namespace CristoRey.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReporteMatricula()
        {
           

            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/ReporteMatricula.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult ReportePrimaria()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/ReportePrimaria.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult ReporteSecundaria()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/ReporteSecundaria.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }


        //PRIMARIA GRADOS 

        public ActionResult Reporte1P()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte1P.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte2P()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte2P.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte3P()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte3P.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte4P()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte4P.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte5P()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte5P.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte6P()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte6P.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }


        //PRIMARIA SECCIONES
        public ActionResult Reporte1AP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte1AP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte1BP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte1BP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte2AP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte2AP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte2BP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte2BP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte3AP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte3AP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte3BP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte3BP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte4AP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte4AP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte4BP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte4BP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte5AP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte5AP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte5BP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte5BP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte6AP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte6AP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte6BP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Primaria/Reporte6BP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }


        //SECUNDARIA GRADOS

        public ActionResult Reporte1S()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte1S.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte2S()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte2S.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte3S()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte3S.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte4S()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte4S.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte5S()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte5S.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }



        //SECUNDARIA SECCIONES
        public ActionResult Reporte1AS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte1AS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte1BS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte1BS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte2AS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte2AS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte2BS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte2BS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte3AS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte3AS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte3BS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte3BS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte4AS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte4AS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte4BS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte4BS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte5AS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte5AS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        public ActionResult Reporte5BS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_matriculados", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Secundaria/Reporte5BS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

        //Proforma

        public ActionResult ProformaG()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getproforma", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Proforma/ProformaG.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }



        public ActionResult ProformaP()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getproforma", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Proforma/ProformaP.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }


        public ActionResult ProformaS()
        {


            String cnn = @"data source = TOSHIBA; initial catalog = BD_Colegio; persist security info = True; user id = sa; password = 12345;";
            SqlConnection con = new SqlConnection(cnn);

            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getproforma", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception e)
            {
            }

            ReportClass rpth = new ReportClass();
            rpth.FileName = Server.MapPath("~/Reporte/Proforma/ProformaS.rpt");
            rpth.Load();
            rpth.SetDataSource(dt);
            Stream stream = rpth.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }

    }
}