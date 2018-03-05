using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TipoProducto
    {
        public int? Id { get; set; }
        [Display(Name = "Tipo")]
        [StringLength(250, MinimumLength = 4, ErrorMessage = "El Nombre debe ser min 5 y maximo 40")]
        public string NombreTipo { get; set; }
        [Display(Name = "Nombre Familia")]
        public int IdFamilia { get; set; }
        public FamiliaTipoArticulo FamiliaTipoArticulo { get; set; }

    }
}
