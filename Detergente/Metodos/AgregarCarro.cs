using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Detergente.Metodos
{
    public static partial class AgregarCarro
    { 
        static int contar;
        public static string Agregar(Producto producto,string sesion) {
            contar = +1;
            List<Carrito> Lista;
            if (sesion == null)
                Lista = new List<Carrito>();
            else {
                Lista = JsonConvert.DeserializeObject<List<Carrito>>(sesion);
            }


            List<Producto> Pro = new List<Producto>();
            Pro.Add(producto);
            var carrito = new Carrito(contar, producto.Id, 1, DateTime.Now, producto);
            Lista.Add(carrito);

            return JsonConvert.SerializeObject(Lista, Formatting.Indented);

        }
        public static List<Carrito> Listar() {

            return null;
        }
    }
}