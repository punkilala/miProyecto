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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Listado()
        {
            return PartialView(mInscritos.GetMisCandidaturas());
        }
    }
}