using AccesoDatos.DataContext;
using Modelos;

namespace AccesoDatos.Repositorios
{
    public class RepositorioColor
    {
        private readonly TallerMecanicoContext _context;

        public RepositorioColor(TallerMecanicoContext context)
        {
            _context = context;
        }


        public Color ObtenerColor(int id)
        {
            Color color = _context.Color.Find(id);
            return color;
        }
    }
}
