using AccesoDatos.DataContext;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System.Xml;

namespace AccesoDatos.Repositorios
{
    public class RepositorioDetalleRevision
    {
        private readonly TallerMecanicoContext _context;

        public RepositorioDetalleRevision(TallerMecanicoContext context)
        {
            _context = context;
        }

        public void CrearDetalleRevision(int id_revision, List<Servicio> servicios)
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
