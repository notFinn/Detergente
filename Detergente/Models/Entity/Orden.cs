using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Detergente.Models.Entity
{
    [Bind(Exclude = "OrdenId")]
    public partial class Orden
    {
        [ScaffoldColumn(false)]
        public int OrdenId { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
           ErrorMessage = "Email no valido")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email es requerido")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public DateTime FechaOrden { get; set; }

        public List<DetalleOrden> DetalleOrden { get; set; }

    }
}