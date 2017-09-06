using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RamonZaragoza.Areas.Admin.Controllers
{
    public class CandidaturasController : Controller
    {
        Inscritos mInscritos = new Inscritos();
        InscritosHistorial mHistorial = new InscritosHistorial();
        Estado mEstado = new Estado();
        public ActionResult Index()
        {
            Session["menuActivo"] = 6;
            return View();
        }
        public ActionResult _Listado()
        {
            return PartialView(mInscritos.GetMisCandidaturas());
        }
        public ActionResult Historial (int id)
        {
            var historial = mHistorial.GetHistorial(id);
            // solo ver el historial de mis candidaturas
            if (historial.Count()==0)
            {
                return RedirectToAction("", "Usuario", null);
            }
            return View(historial);
        }
    }
}