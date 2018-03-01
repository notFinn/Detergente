using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Detergente.Models.Entity
{
    public class Producto
    {
        private DateTime? _dateTime;

        public int? Id { get; set; }
        [StringLength(40, MinimumLength = 5, ErrorMessage = "El Nombre debe ser min 5 y maximo 40")]
        public string Nombre { get; set; }

        [StringLength(250, MinimumLength = 10, ErrorMessage = "El Nombre debe ser min 5 y maximo 40")]
        public string Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public double Precio { get; set; }
        public int? IdTipoProducto { get; set; }
        public TipoProducto TipoProducto { get; set; }

        public DateTime? FechaIngreso { get => _dateTime; set => _dateTime = DateTime.Now; }
       

    }

}