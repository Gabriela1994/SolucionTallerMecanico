using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Modelos
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }
        public string Nombre_servicio { get; set; }
        public double Precio_estimado { get; set; }

        [JsonIgnore]
        public List<Revision> Revisiones { get; set; }


        public Servicio(string nombre_servicio, double precio_estimado)
        {
            Nombre_servicio = nombre_servicio;
            Precio_estimado = precio_estimado;
        }        
        public Servicio()
        {

        }

        static string FormatearComoMoneda(double precio_estimado)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:C}", precio_estimado);
        }
    }
}
