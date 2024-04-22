using AccesoDatos.DataContext;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        {

            using (_context)
            {
                Servicio servicio = new Servicio(nombre_servicio: value.Nombre_servicio, precio_estimado: value.Precio_estimado);
                _context.Servicio.Add(servicio);
                _context.SaveChanges();
            }
        }

        public void EditarServicio(int id, Servicio value)
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
        {
            using (_context)
            {
                Servicio servicio_existente = ObtenerServicioPorId(id);
                _context.Remove(servicio_existente);
                _context.SaveChanges();
            }
        }

        public Servicio ObtenerServicioPorId(int id)
        { 
            Servicio servicio = _context.Servicio.Find(id);
            return servicio;
        }        
        public List<Servicio> ObtenerListaServiciosPorId(List<int> id_servicio) //probar
        {
            Servicio servicio = new Servicio();
            var registros = _context.Servicio.Where(t => id_servicio.Contains(t.IdServicio)).ToList();
            return registros;
        }
    }
}