using System.ComponentModel.DataAnnotations;


namespace Modelos
{
    public class Revision
    {
        [Key]
        public int IdRevision {  get; set; }

        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Fecha_ingreso { get; set; }
        public TimeSpan Hora { get; set; }

        public int IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public List<Servicio> Servicios { get; set; }

        public Revision(DateTime fecha, TimeSpan hora, Vehiculo vehiculo)
        {
            Fecha_ingreso = fecha;
            Hora = hora;
            Vehiculo = vehiculo;
        }
        public Revision()
        {


        }

        public TimeSpan HoraRevision()
        {
            TimeSpan horaActual = TimeSpan.Parse(string.Join(":", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            return horaActual;
        }

        public DateTime FechaRevision()
        {
            DateTime fechaActual = Convert.ToDateTime(string.Join("/", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year));
            return fechaActual;
        }
    }
}
