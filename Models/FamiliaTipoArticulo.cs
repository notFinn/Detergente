using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class FamiliaTipoArticulo
    {
        public int? Id { get; set; }
        [Display(Name = "Nombre Familia")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = " Largo Minimo 5 y maximo 50")]
        public string NombreFamilia { get; set; }
    }
}
