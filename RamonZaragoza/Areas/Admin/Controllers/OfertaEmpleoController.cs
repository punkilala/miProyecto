using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Helper;

namespace RamonZaragoza.Areas.Admin.Controllers.Empresa
{
    public class OfertaEmpleoController : Controller
    {
        OfertaEmpleo mOferta = new OfertaEmpleo();
        Categoria mCategoria = new Categoria();
        public ActionResult Index()
        {
            Session["menuActivo"] = 1;
            return View();
        }
        public ActionResult _Listado(Filtro filtro, int? displayNum, int? pagina)
        {
            int numPag = pagina ?? 1;
            int maxReg = displayNum ?? 8;

            if (filtro.CambiarEstado > 0)
            {
                mOferta.CambiarEstado(filtro.CambiarEstado);
            }

            return PartialView(mOferta.GetLista(filtro).ToPagedList(numPag,maxReg));
        } 
        public ActionResult Acciones (int id = 0)
        {
            if (id == 0)
            {
                mOferta.id = 0;
                mOferta.Usuario_id = SesionHelper.GetUser();
                ViewBag.Title = "Agregar Oferta de empleo";
            }
            else
            {

            }
            ViewBag.Categoria_id = mCategoria.GetListado();
            return View(mOferta);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Acciones (OfertaEmpleo modelo)
        {
            ViewBag.Categoria_id = mCategoria.GetListado();
            return View();
        }
    }
}