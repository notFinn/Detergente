using Detergente.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Detergente.ViewModels
{
    public class CarritoCompraViewModel
    {
        public List<Carrito> Carritos { get; set; }
        public decimal carritoTotal { get; set; }
    }
}