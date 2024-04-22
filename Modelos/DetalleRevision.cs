using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class DetalleRevision
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdRevision { get; set; }
        public int IdServicio { get; set; }
    }
}
