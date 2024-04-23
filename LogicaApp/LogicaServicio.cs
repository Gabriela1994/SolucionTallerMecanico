using AccesoDatos.DataContext;
using AccesoDatos.Repositorios;
using Modelos.ClasesCustom;
using Modelos;

namespace LogicaApp
{
    public class LogicaServicio
    {
        private readonly TallerMecanicoContext _context;

        public LogicaServicio(TallerMecanicoContext context)
        {
            _context = context;
        }

        public List<Servicio> ListarServicios()
        //Devuelve la lista de servicios.
        {
            RepositorioServicio repoServicio = new RepositorioServicio(_context);
            return repoServicio.ListaServicios();
        }

        public void CrearServicio(CrearServicio servicio)
        //Crea un servicio, primero verifica si no es null el parametro recibido.
        {
            try
            {
                if (servicio != null)
                {
                    Servicio objServicio = new Servicio(nombre_servicio: servicio.Nombre_servicio, precio_estimado: servicio.Precio_estimado);
                    RepositorioServicio repoServicio = new RepositorioServicio(_context);
                    repoServicio.CargarServicio(objServicio);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Descripcion del error:", e);
            }
        }

        public void EditarServicio(int id_servicio, CrearServicio servicio)
        //Edita un servicio, primero verifica que el id no sea 0.
        {
            try
            {
                if (id_servicio != 0)
                {
                    RepositorioServicio repoServicio = new RepositorioServicio(_context);
                    Servicio servicio_encontrado = new Servicio();

                    servicio_encontrado.Nombre_servicio = servicio.Nombre_servicio;
                    servicio_encontrado.Precio_estimado = servicio.Precio_estimado;

                    repoServicio.EditarServicio(id_servicio, servicio_encontrado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Descripcion del error:", e);
            }
        }

        public void EliminarServicio(int id_servicio)
        //Elimina un servicio, primero verifica que el id no sea 0.
        {
            try
            {
                RepositorioServicio repoServicio = new RepositorioServicio(_context);
                if (id_servicio != 0)
                {
                    repoServicio.EliminarServicio(id_servicio);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Descripcion del error:", e);
            }
        }

        public Servicio ObtenerServicioPorId(int id_servicio)
        //Obtiene el servicio buscandolo por su id.
        {
            RepositorioServicio repoServicio = new RepositorioServicio(_context);
            return repoServicio.ObtenerServicioPorId(id_servicio);
        }
    }
}