using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace RamonZaragoza.Areas.Admin.Controllers
{
    public class InscritosController : Controller
    {
        OfertaEmpleo mOferta = new OfertaEmpleo();
        Inscritos mInscritos = new Inscritos();
        Estado mEstado = new Estado();
        public ActionResult Oferta(int id=0)
        {
            // Recordar a que oferta tengo que volver
            Session["NumOferta"] = id;


            var oferta = mOferta.GetOferta(id);
            //solo ver mis ofertas
            if (oferta == null)
            {
                return RedirectToAction("Index", "Usuario");
            }
            ViewBag.Estado = oferta.Abierta;
            ViewBag.Nombre = oferta.Nombre;
            return View();
        }
        public ActionResult _Listado(int id, int? pagina, int? displayNum, int? estado_id )
        {
            int numPag = pagina ?? 1; 
            int numReg = displayNum ?? 10;
            int estado = estado_id ?? 4;

            // recordar en que estado estoy filtrando para cuando vuelva.. lo leo en vista DatosUsuario 
            // para componer la url de retorno
            Session["EstadoFiltro"] = estado;

            ViewBag.LEstado = mEstado.GetEstadoInscrito();
            return PartialView(mInscritos.GetInscritos(id, estado).ToPagedList(numPag,numReg));
        }
        public ActionResult DatosUsuario(int id, Int64 inscrip, int estado)
        {
            // inscripcion que aun no he leido
            if (estado==4)
            {
                // marcar leido
                mInscritos.SetModifiEstado(inscrip, id, 5);
            }
            
            
            return View (mInscritos.GetInscripcion(inscrip));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DatosUsuario (Inscritos modelo)
        {

            string respuestaAjax;
            
            mInscritos.SetModifiEstado(modelo.NumInscripcion, modelo.Usuario_id_D, modelo.estado_id);
            if (modelo.estado_id == 6)
            {
                respuestaAjax = "Estado: <span class='badge' style='background:#343A40; color:white;'>Rechazado</span>"; 
            } else
            {
                respuestaAjax = "Estado: <span class='badge' style='background:#28A745; color:white;'>Pre-Selec</span>";
            }
            return Json(respuestaAjax);

        }
    }
}