﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mobileCRM.Models;

namespace mobileCRM.Controllers
{
    public class VisitaController : Controller
    {
        private int handleUsuario;
        //
        // GET: /Visita/

        public ActionResult Index()
        {
            Usuario user = (Usuario)Session["usuario"];
            if (user != null)
            {
                handleUsuario = user.Handle;
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }

            IRepositoryVisitas visitasRep = new VisitaRepository();
            var visitas = visitasRep.BuscaTodasByUsuario(handleUsuario);

            return View(visitas);
        }

        //
        // GET: /Visita/Details/5

        public ActionResult Details(int id)
        {
            IRepositoryVisitas visitasRep = new VisitaRepository();
            var visitas = visitasRep.BuscaByHandle(id);

            return View(visitas);
        }

        //
        // GET: /Visita/Create

        public ActionResult Create()
        {
            ViewBag.valorTipoCliente = 1;
            return View(new Visita());
        } 

        //
        // POST: /Visita/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public JsonResult Teste()
        {
            List<Clientes> Allclientes = new List<Clientes>();
            Allclientes.Add(new Clientes { Handle = 1, Nome = " Clientes 1" });
            Allclientes.Add(new Clientes { Handle = 3, Nome = " Clientes 3" });
            Allclientes.Add(new Clientes { Handle = 4, Nome = " Clientes 4" });
            return Json(Allclientes, JsonRequestBehavior.AllowGet);
        }
        
        //
        // GET: /Visita/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Visita/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Visita/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Visita/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
