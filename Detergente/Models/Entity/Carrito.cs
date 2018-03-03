using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Detergente.Models.Entity
{
    public class Carrito
    {
        [Key]
        public int GuardarId { get; set; }
        public string CartId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual Producto Producto { get; set; }

    }
}