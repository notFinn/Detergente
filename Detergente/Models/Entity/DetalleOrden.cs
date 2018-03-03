namespace Detergente.Models.Entity
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Orden Orden { get; set; }

    }
}