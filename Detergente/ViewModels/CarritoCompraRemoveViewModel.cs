using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Detergente.ViewModels
{
    public class CarritoCompraRemoveViewModel
    {
        public string Mensaje { get; set; }
        public decimal CarritoTotal { get; set; }
        public int CantidadCarrito { get; set; }
        public int ItemCantidad { get; set; }
        public int DeleteId { get; set; }
    }
}