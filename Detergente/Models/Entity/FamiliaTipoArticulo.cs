using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Detergente.Models.Entity
{
    public class FamiliaTipoArticulo
    {
        public int? Id { get; set; }
        [Display(Name ="Nombre Familia")]
        [StringLength(50,MinimumLength =5,ErrorMessage =" Largo Minimo 5 y maximo 50")]
        public string NombreFamilia { get; set; }
    }
}