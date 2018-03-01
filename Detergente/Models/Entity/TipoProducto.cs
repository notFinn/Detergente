using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Detergente.Models.Entity
{
    public class TipoProducto
    {
        public int? Id { get; set; }
        public string NombreTipo { get; set; }
        public int IdFamilia { get; set; }
        public FamiliaTipoArticulo FamiliaTipoArticulo { get; set; }

    }
}