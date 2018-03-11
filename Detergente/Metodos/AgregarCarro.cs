using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Detergente.Metodos
{
    public static partial class AgregarCarro
    {
        static int contar;
        public static string Agregar(Producto producto, string sesion) {
            contar = +1;
            List<Carrito> Lista;

            if (sesion == null)
                Lista = new List<Carrito>();
            else {
                Lista = JsonConvert.DeserializeObject<List<Carrito>>(sesion);
            }

            List<Producto> Pro = new List<Producto>();
            Pro.Add(producto);
            foreach (var lpro in Lista)
            {
                if (lpro.IdProduco == producto.Id)
                {
                    lpro.Cantidad = lpro.Cantidad + 1;
                    return JsonConvert.SerializeObject(Lista, Formatting.Indented);
                }

            }
            var carrito = new Carrito(contar, producto.Id, 1, DateTime.Now, producto);
            Lista.Add(carrito);

            return JsonConvert.SerializeObject(Lista, Formatting.Indented);

        }
        public static List<Carrito> Listar() {

            return null;
        }
        public static int ContarCarrito(string json) {

            List<Carrito> Lista;
            if (json == null)
                return 0;
            else {
                Lista = JsonConvert.DeserializeObject<List<Carrito>>(json);
            }
            int cont = 0;
            foreach (var pro in Lista)
            {
                cont = cont + pro.Cantidad;
            }

            return cont;
        }
        public static int TotalizarCarrito(string json)
        {

            List<Carrito> Lista;
            if (json == null)
                return 0;
            else
            {
                Lista = JsonConvert.DeserializeObject<List<Carrito>>(json);
            }
            int cont = 0;
            foreach (var pro in Lista)
            {
                cont = (int)(cont + (pro.Cantidad * pro.Producto.Precio));
            }

            return cont;
        }

        public static List<Carrito> ProductosCarritosJson(string json) {
            List<Carrito> Lista;
            if (json == null)
                return null;
            else
            {
                Lista = JsonConvert.DeserializeObject<List<Carrito>>(json);
            }
            

            return Lista;

        }
    }
}