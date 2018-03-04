using Detergente.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Detergente.Metodos
{
    public static partial class AgregarCarro
    { 
        static List<Carrito> Lista = new List<Carrito>();
        static int contar;
        public static void Agregar(Producto producto) {

            contar =+ 1;
            List<Producto> Pro = new List<Producto>();
            Pro.Add(producto);
            var carrito = new Carrito(contar, producto.Id, 1, DateTime.Now, producto);
            Lista.Add(carrito);
        }

    }
}