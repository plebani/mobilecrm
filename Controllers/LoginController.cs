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

                if ((email == "fernando.alex@benner.com.br") && (password == "123"))
                {
                    ViewBag.informacao = "Logando...";
                    System.Threading.Thread.Sleep(1000);
                    RedirectToAction("Index");
                }
                else
                {
                    ViewBag.informacao = "Babacaaaa";
                }
            }

            return View();
        }
    }
}
