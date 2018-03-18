using Google.Maps;
using Google.Maps.Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public class MapGoogle
    {
        public static string ConsultarDistancia(string direccion)
        {
            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyAJEX5MZtX7pA13_QW0hXWtQzjeTwvuxiI"));
            var request = new GeocodingRequest
            {
                Address = direccion
            };
            var repuesta = new GeocodingService().GetResponse(request);

            if (repuesta.Status == ServiceResponseStatus.Ok && repuesta.Results.Count() > 0)
            {
                var result = repuesta.Results.First();

                double metros = calcularMetros(result.Geometry.Location.Latitude, result.Geometry.Location.Longitude,-33.572429,-70.566485,'K');
                return result.FormattedAddress+" kilometro "+metros;

            }
            else {
                string error = "No esta disponible el geocode. Status= " + repuesta.Status + "  y Mensaje error" +repuesta.ErrorMessage +"";
                return error;
            }
            
        }

        private static double calcularMetros(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double deg2radMultiplier = Math.PI / 180;
            lat1 = lat1 * deg2radMultiplier;
            lon1 = lon1 * deg2radMultiplier;
            lat2 = lat2 * deg2radMultiplier;
            lon2 = lon2 * deg2radMultiplier;

            double radius = 6378.137; // earth mean radius defined by WGS84
            double dlon = lon2 - lon1;
            double distance = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(dlon)) * radius;
            
                return (distance);
           
        }
    }
}
