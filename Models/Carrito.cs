using System;

namespace Models
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdProduco { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCrecion { get; set; }
        public Producto Producto { get; set; }

        public Carrito(int idCarrito, int idProduco, int cantidad, DateTime fechaCrecion, Producto producto)
        {
            IdCarrito = idCarrito;
            IdProduco = idProduco;
            Cantidad = cantidad;
            FechaCrecion = fechaCrecion;
            Producto = producto;
        }
    }
}
