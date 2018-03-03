using Detergente.Models;
using Detergente.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Detergente.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ApplicationDbContext TiendaDb = new ApplicationDbContext();
        const string PromoCode = "FREE";
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Orden();
            TryUpdateModel(order);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Email = User.Identity.Name;
                    order.FechaOrden = DateTime.Now;

                    //Save Order
                    TiendaDb.Orden.Add(order);
                    TiendaDb.SaveChanges();
                    //Process the order
                    var cart = CarritoCompra.GetCarrito(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Completo",
                        new { id = order.OrdenId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = TiendaDb.Orden.Any(
                o => o.OrdenId == id &&
                o.Email == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}