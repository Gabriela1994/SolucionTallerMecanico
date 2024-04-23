using AccesoDatos.DataContext;
using Modelos;

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
        //Obtiene la lista de marcas.
        {
            Marca marca = _context.Marca.Find(id);
            return marca;
        }
    }
}