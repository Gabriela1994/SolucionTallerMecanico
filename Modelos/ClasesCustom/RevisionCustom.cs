using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Modelos.ClasesCustom
{
    public class CrearRevision
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public int IdVehiculo { get; set; }
        public List<int> Servicios { get; set; }
    }
    public class ListaRevisiones
    {
        public int Id_revision { get; set; }        
        public DateTime Fecha { get; set; }        
        public TimeSpan Hora { get; set; }
        public string Matricula { get; set; }
        public List<Servicio> Servicios { get; set; }
    }

}