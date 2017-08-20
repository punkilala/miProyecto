using RamonZaragoza.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RamonZaragoza.Areas.Admin.Controllers
{
    [Autenticado]
    public class ExperienciaController : Controller
    {
       
        public ActionResult Index(int tipo)
        {
            ViewBag.Title = tipo == 1 ? "Trabajos realizados" : "Estudios previos";
            return View();
        }
    }
}