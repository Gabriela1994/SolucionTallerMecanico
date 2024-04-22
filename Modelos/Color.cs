using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modelos
{
    public class Color
    {
        [Key]
        public int IdColor { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public List<Vehiculo> Vehiculos { get; set; }
    }
}
