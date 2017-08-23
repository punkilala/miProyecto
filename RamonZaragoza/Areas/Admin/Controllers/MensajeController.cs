﻿using Helper;
using Models;
using PagedList;
using RamonZaragoza.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RamonZaragoza.Areas.Admin.Controllers
{
    [Autenticado]
    public class MensajeController : Controller
    {
        Mensaje mMensajes = new Mensaje();
        RespuestaServidor mRespuestaAjax;

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _Listado(int[] idEliminar, int? pagina, int ? estado_id)
        {
            if (idEliminar != null)
            {
                int queBorro = Convert.ToInt16(Session["EstadoMensajes"]);
                bool result = true;
                for (int i = 0; i < idEliminar.Count() && result == true; i++)
                {
                    result = mMensajes.EliminarMensaje(idEliminar[i]);  
                    if (result && queBorro == 1) RestarMensajeSinLeer();
                }   
            }

            int numPag = pagina ?? 1;
            int maxReg = 5;
            int estado = estado_id ?? 1;

            //para saber si leo algun mensaje a donde tengo que volver, si a 'sin leer' o a leidos'
            //en las vista LeerMensajes leo esta variable de sesion antes de regresar
            Session["EstadoMensajes"] = estado;

            var mensajes = mMensajes.ListaMensajes(SesionHelper.GetUser(),estado).ToPagedList(numPag, maxReg);

            if (estado == 1) ViewBag.Estado = "Sin Leer";
            else ViewBag.Estado = "Leidos";

            return PartialView(mensajes);
        }

        public ActionResult LeerMensaje(int id)
        {
            mMensajes = mMensajes.LeerMensaje(id);
            int queLeo = Convert.ToInt16(Session["EstadoMensajes"]);
            //queLeo=1 es mensaje nuevo
            if (queLeo==1) RestarMensajeSinLeer();
            return View(mMensajes);
        }
        private void RestarMensajeSinLeer()
        {
            int mensajesSinLeer = Convert.ToInt16(@Session["MensajesSinLeer"]);            
            mensajesSinLeer--;
            Session["MensajesSinLeer"] = mensajesSinLeer;
        }
        
    }
}