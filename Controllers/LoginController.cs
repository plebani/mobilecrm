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

                var user = ctx.Usuarios.Where(p => p.Nome == nome && p.Senha == password).SingleOrDefault();
                
                if (user != null)
                {
                    Session["usuario"] = user;
                    ViewBag.informacao = "Logando...";
                    ViewBag.usuario = string.Format("{0} {1}", user.Nome, user.Sobrenome);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.informacao = "Usuário/Senha incorretos.";
                }
            }

            return View();
        }
        
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}
