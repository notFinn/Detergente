using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Detergente.Models.Entity
{
    public class Producto
    {
        private DateTime? _fechaActualizacion;

        public int? Id { get; set; }
        [StringLength(40, MinimumLength = 5, ErrorMessage = "El Nombre debe ser min 5 y maximo 40")]
        public string Nombre { get; set; }

        [StringLength(250, MinimumLength = 10, ErrorMessage = "El Nombre debe ser min 5 y maximo 40")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public double Precio { get; set; }
        [Display(Name ="Tipo de Producto")]
        public int? IdTipoProducto { get; set; }
        public TipoProducto TipoProducto { get; set; }

        public DateTime? FechaActualizacion { get => _fechaActualizacion; set => _fechaActualizacion = DateTime.Now; }
        [Display(Name ="Imagen")]
        public string ImagePath { get; set; }
        public Boolean Disponible { get; set; }

    }


}