using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RamonZaragoza.Controllers
{
    public class OfertasController : Controller
    {
        OfertaEmpleo mOferta = new OfertaEmpleo();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detalle (int id)
        {
            return View(mOferta.GetOfertaDetalle(id));
        }
    }
}