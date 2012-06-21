using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mobileCRM.Models;

namespace mobileCRM.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/
        
        public ActionResult Index()
        {
            ViewBag.informacao = string.Empty;
            ViewBag.usuario = string.Empty;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            CRMEntities ctx = new CRMEntities();
            
            string nome = string.Empty;
            string password = string.Empty;

            if (collection.Count > 0)
            {
                nome     = collection["nome"];
                password = collection["password"];

                var x = ctx.Usuarios.Where(p => p.Nome == nome && p.Senha == password).SingleOrDefault();
                
                if (x != null)
                {
                    ViewBag.informacao = "Logando...";
                    ViewBag.usuario    = string.Format("{0} {1}", x.Nome, x.Sobrenome);
                    System.Threading.Thread.Sleep(1000);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.informacao = "Falha ao executar login.";
                }
            }

            return View();
        }
    }
}
