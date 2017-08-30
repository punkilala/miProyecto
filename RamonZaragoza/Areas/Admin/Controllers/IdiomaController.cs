using Helper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RamonZaragoza.Areas.Admin.Controllers
{
    public class IdiomaController : Controller
    {
        Idioma mIdioma = new Idioma();
        Idiomas mIdiomas = new Idiomas();
        Estado mEstado = new Estado();
        public ActionResult Index()
        {
            Session["menuActivo"] = 4;
            return View(mIdioma.GetIdiomas(SesionHelper.GetUser()));
        }
        public ActionResult Acciones (int id=0)
        {
            if (id == 0)
            {
                ViewBag.Title = "Nuevo idioma";
                mIdioma.id = 0;
                mIdioma.Usuario_id = SesionHelper.GetUser();
                //Todos los idiomas menos los que ya tiene el usuario
                ViewBag.IdiomasDisponibles = mIdiomas.GetIdiomasDisponibles();
            }
            else
            {
                ViewBag.Title = "Modificar Idioma";
                mIdioma = mIdioma.GetIdioma(id, SesionHelper.GetUser());
            }  
            
            ViewBag.Nivel = mEstado.GetNiveles();
            return View(mIdioma);
        }
    }
}