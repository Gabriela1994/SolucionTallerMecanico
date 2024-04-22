using AccesoDatos.DataContext;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class RepositorioMarca
    {
        private readonly TallerMecanicoContext _context;

        public RepositorioMarca(TallerMecanicoContext context)
        {
            _context = context;
        }


        public Marca ObtenerMarca(int id)
        {
            Marca marca = _context.Marca.Find(id);
            return marca;
        }
    }
}
