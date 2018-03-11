using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Detergente.Controllers
{
    public class CarritoCompraController : Controller
    {
        // GET: CarritoCompra
        public ActionResult ListaCarrito()
        {
            return View();
        }
    }
}