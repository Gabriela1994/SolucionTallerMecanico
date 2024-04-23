using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Modelos
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public string Matricula { get; set; }
        public Marca Marca { get; set; }
        public Color Color { get; set; }
        public string Modelo { get; set; }

        [JsonIgnore]
        public List<Revision> Revision { get; set; }

        public Vehiculo(string matricula, Marca marca, Color color, string modelo) 
        {
            Matricula = matricula;
            Marca = marca;
            Color = color;
            Modelo = modelo;            
        }
        public Vehiculo()
        {

        }
    }
}
