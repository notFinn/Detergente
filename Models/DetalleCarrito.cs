namespace Models
{
    public class DetalleCarrito
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdPedido { get; set; }
        public string Correo { get; set; }
        public Pedido Pedido { get; set; }
        public ApplicationUser Email { get; set; }
        public Producto Producto { get; set; }
    }
}