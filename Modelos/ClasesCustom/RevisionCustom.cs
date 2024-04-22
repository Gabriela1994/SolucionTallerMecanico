using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Modelos.ClasesCustom
{
    public class CrearRevision
    {
        public int IdRevision { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public int IdVehiculo { get; set; }
        public List<int> Servicios { get; set; }
    }
}