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
    public class RepositorioRevision
    {
        private readonly TallerMecanicoContext _context;

        public RepositorioRevision(TallerMecanicoContext context)
        {
            _context = context;
        }


        public List<Revision> ListaRevisiones()
        //Retorno la lista de las revisiones.
        {
            List<Revision> lista_revisiones = new List<Revision>();

            using (_context)
            {
                lista_revisiones = _context.Revision
                    .Include("Vehiculo")
                    .ToList();
            }
            return lista_revisiones;
        }

        public int CrearRevision(Revision value)
        //Crea una revision en la base de datos y retorno el id.
        {
            Revision revision = new Revision();
            revision.IdRevision = value.IdRevision; //??
            revision.Fecha_ingreso = value.Fecha_ingreso;
            revision.Hora = value.Hora;
            revision.Vehiculo = value.Vehiculo;


            _context.Add(revision);
            _context.SaveChanges();

            int id = revision.IdRevision;

            return id;
        }
    }
}
