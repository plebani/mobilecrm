using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mobileCRM.Controllers
{
    public class LoginController : Controller
    {
        //
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
            string email = string.Empty;
            string password = string.Empty;

            if (collection.Count > 0)
            {
                email = collection["email"];
                password = collection["password"];

                if ((email == "alex") && (password == "123"))
                {
                    ViewBag.informacao = "Logando...";
                    System.Threading.Thread.Sleep(1000);
                    ViewBag.usuario = "Alex Plebani";
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
