using AccesoDatos.DataContext;
using Modelos;
using Modelos.ClasesCustom;

namespace AccesoDatos.Repositorios
{
    public class RepositorioDetalleRevision
    {
        private readonly TallerMecanicoContext _context;

        public RepositorioDetalleRevision(TallerMecanicoContext context)
        {
            _context = context;
        }

        public List<ListaRevisiones> ListaDetalleDeRevisiones()
        //Retorno la lista de las revisiones con su detalle incluido.
        {
            List<ListaRevisiones> lista_revisiones = new List<ListaRevisiones>();
            List<Servicio> lista_servicios = new List<Servicio>();

            using (_context)
            {
                lista_revisiones = (from detalle in _context.DetalleRevision
                                    join s in _context.Servicio on detalle.IdServicio equals s.IdServicio
                                    join r in _context.Revision on detalle.IdRevision equals r.IdRevision
                                    join v in _context.Vehiculo on r.IdVehiculo equals v.IdVehiculo
                                    group r by new { r.IdRevision, v.Matricula, r.Fecha_ingreso, r.Hora } into grupo
                                    select new ListaRevisiones
                                    {
                                        Id_revision = grupo.Key.IdRevision,
                                        Matricula = grupo.Key.Matricula,
                                        Fecha = grupo.Key.Fecha_ingreso,
                                        Hora = grupo.Key.Hora,
                                        Servicios = (from detalle in _context.DetalleRevision
                                                     join s in _context.Servicio on detalle.IdServicio equals s.IdServicio
                                                     where detalle.IdRevision == grupo.Key.IdRevision
                                                     select new Servicio
                                                     {
                                                         IdServicio = s.IdServicio,
                                                         Nombre_servicio = s.Nombre_servicio,
                                                         Precio_estimado = s.Precio_estimado
                                                     }).ToList()
                                    }).ToList();
                return lista_revisiones;
            }
        }


        public void CrearDetalleRevision(int id_revision, List<Servicio> servicios)
        //Inserto en la tabla detalleRevision los datos que vienen desde la lista.
        {
            DetalleRevision detalle = new DetalleRevision();
            List<DetalleRevision> servicios_obtenidos = new List<DetalleRevision>();

            for (int i = 0; i < servicios.Count; i++)
            {
                servicios_obtenidos.Add(new DetalleRevision
                {
                    IdRevision = id_revision,
                    IdServicio = servicios[i].IdServicio,
                });
            }
            _context.DetalleRevision.AddRange(servicios_obtenidos);
            _context.SaveChanges(); 
        }
    }
}
