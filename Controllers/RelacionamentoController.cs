using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mobileCRM.Models;

namespace mobileCRM.Controllers
{
    public class RelacionamentoController : Controller
    {
        //
        // GET: /Relacionamento/

        private CRMEntities context = new CRMEntities();

        public ActionResult Index()
        {
            return View();
        }

    }
}
