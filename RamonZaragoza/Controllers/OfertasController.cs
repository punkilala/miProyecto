﻿using Helper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace RamonZaragoza.Controllers
{
    public class OfertasController : Controller
    {
        OfertaEmpleo mOferta = new OfertaEmpleo();
        Categoria mCategoria = new Categoria();
        public ActionResult Index()
        {
            ViewBag.Ciudades = mOferta.GetCiudadConOferta();
            ViewBag.Categorias = mCategoria.GetListado();
            return View();
        }
        public PartialViewResult _Listado()
        {
            var listadoOfertas = mOferta.GetOfertasAbiertas();
            ViewBag.TotalOfertas = listadoOfertas.Count();
            return PartialView(listadoOfertas.ToPagedList(1, 10));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Listado(Filtro filtro, int ? pagina)
        {
            int numPag = pagina ?? 1;
            var listaOfertas = mOferta.GetOfertasAbiertas(filtro);
            ViewBag.TotalOfertas = listaOfertas.Count();
            return PartialView(listaOfertas.ToPagedList(numPag, 10));
        }

        public ActionResult Detalle (int id)
        {
            var oferta = mOferta.GetOfertaDetalle(id);
            ViewBag.UsuarioActivo = SesionHelper.GetUser();
            ViewBag.OfertasRelacionadas = mOferta.GetOfertasRelacionadas(3, oferta.id, oferta.Categoria_id);
            return View(oferta);
        }
    }
}