using AccesoDatos.DataContext;
using AccesoDatos.Repositorios;
using Modelos.ClasesCustom;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        {
            RepositorioServicio repoServicio = new RepositorioServicio(_context);
            return repoServicio.ListaServicios();
        }

        public void CrearServicio(CrearServicio servicio)
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
        {
            RepositorioServicio repoServicio = new RepositorioServicio(_context);
            return repoServicio.ObtenerServicioPorId(id_servicio);
        }
    }
}