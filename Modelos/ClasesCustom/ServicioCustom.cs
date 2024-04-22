using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ClasesCustom
{
    public class CrearServicio
    {
        public string Nombre_servicio { get; set; }
        public double Precio_estimado { get; set; }

        public CrearServicio()
        {

        }
    }

    public class ObtenerServicio
    {
        public int Id_servicio { get; set; }
    }
}