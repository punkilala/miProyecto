using Helper;
using Models;
using RamonZaragoza.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RamonZaragoza.Controllers
{
    [Autenticado]
    public class PerfilController : Controller
    {
        Usuario mUsuario = new Usuario();
        Idioma mIdioma = new Idioma();
        public ActionResult Usuario(int id)
        {
            if (Convert.ToInt16(Session["Rol"]) == 1)
            {
                //el usuario activo solo puede ver su perfil;
                if (id != SesionHelper.GetUser())
                {
                    return Content("<script>window.close();</script>");
                }
            }
            return View(mUsuario.GetDatosPersonales(id));
        }
        public PartialViewResult _MenuContacto(int id)
        {
            return PartialView(mUsuario.GetDatosPersonales(id));
        }
        public PartialViewResult _MostrarCv(int id)
        {
            return PartialView(mUsuario.GetDatosCv(id));
        }
        public PartialViewResult _MostrarIdiomas (int id)
        {
            return PartialView(mIdioma.GetIdiomas(id));
        }
        public PartialViewResult _EnviarMensaje()
        {
            return PartialView(new Mensaje());
        }
        

        public ActionResult ExportaPdf(int id)
        {
            return new Rotativa.MVC.ActionAsPdf("PDF", new { id=id});
        }
        public ActionResult PDF(int id)
        {
            return View(mUsuario.GetDatosPersonales(id));
        }
    }
}