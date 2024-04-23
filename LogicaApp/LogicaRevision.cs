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

        //Toda la logica para crear una revision.
        //1.-Obtenemos el vehiculo de la base de datos, que ya tiene que estar creado.
        //2.-Utilizamos los metodos FechaRevision() y HoraRevision() para obtener la fecha y la hora del momento en que se va a crear la revision.
        //3.-Llenamos el objeto revision con los parametros que necesitamos: fecha, hora y vehiculo.
        //4.-Llamamos al repositorio de revision para usar su funcionalidad CrearRevision, y le pasamos por parametro el objeto revision creado anteriormente, y finalmente retornamos la id de ese objeto creado.
        //5.-Llenamos la lista de servicios que tuvo la revision para luego esa lista usarla para el detalleRevision.
        //6.-Llamamos al repositorio de DetalleRevision para usar su funcionalidad CrearDetalleRevision, con sus parametros: id_revision, que lo obtuvimos arriba y la lista de servicios.
        //7.-Guardamos todo el proceso en la base de datos.
        //NOTA: Se estan usando transacciones en el proceso, si el proceso falla, no guarda nada en la base de datos.
        public void CrearRevision(CrearRevision data)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    RepositorioRevision repoRevision = new RepositorioRevision(_context);
                    RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(_context);
                    RepositorioServicio repoServicio = new RepositorioServicio(_context);
                    RepositorioDetalleRevision repoDetalle = new RepositorioDetalleRevision(_context);
                    Revision revision = new Revision();

                    Vehiculo vehiculo_encontrado = repoVehiculo.ObtenerVehiculoPorId(data.IdVehiculo);

                    transaction.CreateSavepoint("Volvemos acá"); //Esto es para crear un rollback en caso de que falle algo en la transaccion.

                    DateTime fecha = revision.FechaRevision();
                    TimeSpan hora = revision.HoraRevision();

                    Revision objRevision = new Revision(fecha, hora, vehiculo_encontrado);
                    int id_revision = repoRevision.CrearRevision(objRevision); //creo la revision y obtengo el id para usarlo luego.

                    List<Servicio> lista_servicios = new List<Servicio>();
                    
                    foreach (var n in data.Servicios)
                    {
                        var item = repoServicio.ObtenerServicioPorId(n);
                        lista_servicios.Add(item);                        
                    }

                    repoDetalle.CrearDetalleRevision(id_revision, lista_servicios); //acá uso el id de la revision para crear su detalle.
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