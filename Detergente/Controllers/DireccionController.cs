using Mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Detergente.Controllers
{
    public class DireccionController : Controller
    {
        // GET: Direccion
        public ActionResult CalcularDistancia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalcularDistancia(string Direccion)
        {
            if ( Direccion.Trim().Length > 1)
            {
                var map = MapGoogle.ConsultarDistancia(Direccion);
                ViewBag.Message = map;
            }
            else {
                ViewBag.Message = "Vuelva a ingresar";
            }

            

            return View();
        }
    }
}