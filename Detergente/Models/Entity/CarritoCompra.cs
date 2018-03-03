using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Detergente.Models.Entity
{
    public partial class CarritoCompra
    {
        ApplicationDbContext tiendaDB = new ApplicationDbContext();
        public string CarritoCompraId { get; set; }
        public const string CartSessionKey = "CarritoId";
        public static CarritoCompra GetCarrito(HttpContextBase context) {
            var carrito = new CarritoCompra();
            carrito.CarritoCompraId = carrito.GetCartId(context);
                return carrito;
        }
        public static CarritoCompra GetCart(Controller controller)
        {
            return GetCarrito(controller.HttpContext);
        }

        public void AddToCart(Producto producto)
        {
            // Get the matching cart and album instances
            var cartItem = tiendaDB.Carrito.SingleOrDefault(
                c => c.CartId == CarritoCompraId
                && c.ProductoId == producto.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Carrito
                {
                    ProductoId = producto.Id,
                    CartId = CarritoCompraId,
                    Cantidad = 1,
                    FechaCreacion = DateTime.Now
                };
                tiendaDB.Carrito.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Cantidad++;
            }
            // Save changes
            tiendaDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = tiendaDB.Carrito.Single(
                cart => cart.CartId == CarritoCompraId
                && cart.GuardarId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Cantidad > 1)
                {
                    cartItem.Cantidad--;
                    itemCount = cartItem.Cantidad;
                }
                else
                {
                    tiendaDB.Carrito.Remove(cartItem);
                }
                // Save changes
                tiendaDB.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = tiendaDB.Carrito.Where(
                cart => cart.CartId == CarritoCompraId);

            foreach (var cartItem in cartItems)
            {
                tiendaDB.Carrito.Remove(cartItem);
            }
            // Save changes
            tiendaDB.SaveChanges();
        }
        public List<Carrito> GetCartItems()
        {
            return tiendaDB.Carrito.Where(
                cart => cart.CartId == CarritoCompraId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in tiendaDB.Carrito
                          where cartItems.CartId == CarritoCompraId
                          select (int?)cartItems.Cantidad).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in tiendaDB.Carrito
                              where cartItems.CartId == CarritoCompraId
                              select (decimal?)cartItems.Cantidad *
                              cartItems.Producto.Precio).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Orden order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new DetalleOrden
                {
                    ProductoId = item.ProductoId,
                    OrdenId = order.OrdenId,
                    PrecioUnitario = item.Producto.Precio,
                    Cantidad = item.Cantidad
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Cantidad * item.Producto.Precio);

                tiendaDB.DetalleOrden.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            tiendaDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrdenId;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = tiendaDB.Carrito.Where(
                c => c.CartId == CarritoCompraId);

            foreach (Carrito item in shoppingCart)
            {
                item.CartId = userName;
            }
            tiendaDB.SaveChanges();
        }
    }
}