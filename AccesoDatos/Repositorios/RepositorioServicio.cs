using AccesoDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace AccesoDatos.Repositorios
{
    public class RepositorioServicio
    {
        private readonly TallerMecanicoContext _context;

        public RepositorioServicio(TallerMecanicoContext context)
        {
            _context = context;
        }

        public List<Servicio> ListaServicios()
        //Retorno la lista de los servicios.
        {
            List<Servicio> lista_servicios = new List<Servicio>();

            using (_context)
            {
                lista_servicios = _context.Servicio.ToList();
            }

            return lista_servicios;
        }

        public void CargarServicio(Servicio value)
        //Crea un servicio.
        {
            using (_context)
            {
                Servicio servicio = new Servicio(nombre_servicio: value.Nombre_servicio, precio_estimado: value.Precio_estimado);
                _context.Servicio.Add(servicio);
                _context.SaveChanges();
            }
        }

        public void EditarServicio(int id, Servicio value)
        //Edita un servicio existente, primero revisa si ese id existe en la base de datos.
        {
            using (_context)
            {
                Servicio servicio_existente = ObtenerServicioPorId(id);
                servicio_existente.Nombre_servicio = value.Nombre_servicio;
                servicio_existente.Precio_estimado = value.Precio_estimado;

                _context.Entry(servicio_existente).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void EliminarServicio(int id)
        //Elimina un servicio existente, primero revisa si ese id existe en la base de datos.
        {
            using (_context)
            {
                Servicio servicio_existente = ObtenerServicioPorId(id);
                _context.Remove(servicio_existente);
                _context.SaveChanges();
            }
        }

        public Servicio ObtenerServicioPorId(int id)
        //Obtiene un servicio buscandolo por su id.
        { 
            Servicio servicio = _context.Servicio.Find(id);
            return servicio;
        }
    }
}