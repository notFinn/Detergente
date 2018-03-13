using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string CorreoUsuario { get; set; }
        public int Total { get; set; }
        public Boolean Despacho { get; set; }
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public ApplicationUser Email { get; set; }

    }
    public enum Estado {
        Ingresado =0,

        [Display(Name ="Preparando Pedido")]
        PreparandoPedido=1,

        [Display(Name = "Preparando Entrega")]
        PreparandoEntrega = 2,

        [Display(Name = "Espera al deposito")]
        EsperaDeposito = 3,

        PedidoOK = 4,

        Cancelado = 5,

        [Display(Name = "Anulacion por cliente")]
        RechazoCliente =6
    }


}
