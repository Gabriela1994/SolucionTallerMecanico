using AccesoDatos.DataContext;
using AccesoDatos.Repositorios;
using Modelos;
using Modelos.ClasesCustom;

namespace LogicaApp
{
    public class LogicaRevision
    {
        private readonly TallerMecanicoContext _context;

        public LogicaRevision(TallerMecanicoContext context)
        {
            _context = context;
        }

        public void CrearRevision(CrearRevision data)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Primero recuperamos la informacion para crear el objeto revision.
                    RepositorioRevision repoRevision = new RepositorioRevision(_context);
                    RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(_context);
                    RepositorioServicio repoServicio = new RepositorioServicio(_context);
                    RepositorioDetalleRevision repoDetalle = new RepositorioDetalleRevision(_context);

                    Vehiculo vehiculo_encontrado = repoVehiculo.ObtenerVehiculoPorId(data.IdVehiculo);
                    //int id_vehiculo = vehiculo_encontrado.IdVehiculo;

                    transaction.CreateSavepoint("Volvemos acá"); //Esto es para crear un rollback en caso de que falle algo en la transaccion.
                    Revision revision = new Revision();
                    DateTime fecha = revision.FechaRevision();
                    TimeSpan hora = revision.HoraRevision();

                    Revision objRevision = new Revision(fecha, hora, vehiculo_encontrado);


                    int id_revision = repoRevision.CrearRevision(objRevision);

                    List<Servicio> lista_servicios = new List<Servicio>();
                    
                    foreach (var n in data.Servicios)
                    {
                        var item = repoServicio.ObtenerServicioPorId(n);
                        lista_servicios.Add(item);
                        
                    }

                    repoDetalle.CrearDetalleRevision(id_revision, lista_servicios);

                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.RollbackToSavepoint("Volvemos acá");
                }
            }
        }
    }
}