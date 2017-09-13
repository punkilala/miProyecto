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
            var oferta = mOferta.GetOfertaDetalle(id);
            ViewBag.OfertasRelacionadas = mOferta.GetOfertasRelacionadas(3, oferta.id, oferta.Categoria_id);
            return View(oferta);
        }
    }
}