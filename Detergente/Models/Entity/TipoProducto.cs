using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Detergente.Models.Entity
{
    public class TipoProducto
    {
        public int? Id { get; set; }
        [Display(Name ="Tipo")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "El Nombre debe ser min 5 y maximo 40")]
        public string NombreTipo { get; set; }
        [Display(Name = "Nombre Familia")]
        public int IdFamilia { get; set; }
        public FamiliaTipoArticulo FamiliaTipoArticulo { get; set; }

    }
}