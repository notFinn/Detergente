using Detergente.Models;
using Detergente.Models.Entity;
using Detergente.ViewModels;
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
        ApplicationDbContext TiendaDb = new ApplicationDbContext();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = CarritoCompra.GetCarrito(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new CarritoCompraViewModel
            {
                Carritos = cart.GetCartItems(),
                carritoTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var agregarProducto = TiendaDb.Producto
                .Single(produ => produ.Id == id);

            // Add it to the shopping cart
            var cart = CarritoCompra.GetCarrito(this.HttpContext);

            cart.AddToCart(agregarProducto);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = CarritoCompra.GetCarrito(this.HttpContext);

            // Get the name of the album to display confirmation
            string productoNombre = TiendaDb.Carrito
                .Single(item => item.GuardarId == id).Producto.Nombre;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new CarritoCompraRemoveViewModel
            {
                Mensaje = Server.HtmlEncode(productoNombre) +
                    " El Producto ha sido removido del carrito de compra",
                CarritoTotal = cart.GetTotal(),
                ItemCantidad = cart.GetCount(),
                CantidadCarrito = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = CarritoCompra.GetCarrito(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}
