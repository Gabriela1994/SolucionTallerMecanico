using AccesoDatos.DataContext;
using Modelos;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositorios
{
    public class RepositorioVehiculo
    {
        private readonly TallerMecanicoContext _context;

        public RepositorioVehiculo(TallerMecanicoContext context)
        {
            _context = context;
        }


        public List<Vehiculo> ListaVehiculos()
        //Retorno la lista de los vehiculos.
        {
            List<Vehiculo> lista_vehiculos = new List<Vehiculo>();

            using (_context)
            {
                lista_vehiculos = _context.Vehiculo
                    .Include("Color")
                    .Include("Marca")
                    .ToList();
            }

            return lista_vehiculos;
        }

        public void CargarVehiculo(Vehiculo value)
        {

            using(_context)
            {
                Vehiculo vehiculo = new Vehiculo(matricula: value.Matricula, marca: value.Marca, color: value.Color, modelo: value.Modelo);
                _context.Vehiculo.Add(vehiculo);
                _context.SaveChanges();
            }
        }

        public void EditarVehiculo(int id, Vehiculo value)
        {
            using(_context)
            {
                Vehiculo vehiculo_existente = ObtenerVehiculoPorId(id);
                vehiculo_existente.Matricula = value.Matricula;
                vehiculo_existente.Marca = value.Marca;
                vehiculo_existente.Color = value.Color;
                vehiculo_existente.Modelo = value.Modelo;

                _context.Entry(vehiculo_existente).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void EliminarVehiculo(int id)
        {
            using(_context)
            {
                Vehiculo vehiculo_existente = ObtenerVehiculoPorId(id);
                _context.Remove(vehiculo_existente);
                _context.SaveChanges();
            }
        }

        public Vehiculo ObtenerVehiculoPorId(int id)
        {
            Vehiculo vehiculo = new Vehiculo();
            return vehiculo = _context.Vehiculo
                .Include("Marca")
                .Include("Color")
                .Where(v => v.IdVehiculo == id).FirstOrDefault();
        }
    }
}
