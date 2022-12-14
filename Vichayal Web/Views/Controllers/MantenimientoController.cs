using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Modelo;
using Capa_Negocio;

namespace Vichayal_Web.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Estudiantes()
        {

            return View();
        }

        public JsonResult ListarEstudiante()
        {
            List<Estudiante> eLista = new List<Estudiante>();
            eLista = new CN_Estudiante().CN_ListarEstudiante();
            return Json(new {data = eLista},JsonRequestBehavior.AllowGet);
        }

    }
}