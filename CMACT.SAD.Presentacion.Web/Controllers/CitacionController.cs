using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMACT.SAD.Presentacion.Web.Controllers
{
    public class CitacionController : Controller
    {
        [HttpGet]
        public ActionResult Inicio()
        {
            return RedirectToAction("Error", "Principal");
        }
    }
}