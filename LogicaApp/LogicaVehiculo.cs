


using AccesoDatos.DataContext;
using AccesoDatos.Repositorios;
using Modelos;
using Modelos.ClasesCustom;

namespace LogicaApp
{
    public class LogicaVehiculo
    {
        private readonly TallerMecanicoContext _context;

        public LogicaVehiculo(TallerMecanicoContext context)
        {
            _context = context;
        }


        public List<Vehiculo> ListarVehiculos()
        {
            RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(_context);
            return repoVehiculo.ListaVehiculos();
        }

        public void CrearVehiculo(CrearVehiculo vehiculo)
        {
            try
            {
                if(vehiculo != null)
                {
                    RepositorioMarca repoMarca = new RepositorioMarca(_context);
                    RepositorioColor repoColor = new RepositorioColor(_context);

                    Marca marca = repoMarca.ObtenerMarca(vehiculo.Id_marca);
                    Color color = repoColor.ObtenerColor(vehiculo.Id_color);

                    Vehiculo objVehiculo = new Vehiculo(matricula: vehiculo.Matricula, marca: marca, color: color, modelo: vehiculo.Modelo);
                    RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(_context);
                    repoVehiculo.CargarVehiculo(objVehiculo);
                }
            }catch (Exception e)
            {
                throw new Exception("Descripcion del error:", e);
            }
        }

        public void EditarVehiculo(int id_vehiculo, CrearVehiculo vehiculo)
        {
            try
            {
                if(id_vehiculo != 0)
                {
                    RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(_context);
                    RepositorioMarca repoMarca = new RepositorioMarca(_context);
                    RepositorioColor repoColor = new RepositorioColor(_context);

                    Vehiculo vehiculo_encontrado = new Vehiculo();
                    Marca marca = repoMarca.ObtenerMarca(vehiculo.Id_marca);
                    Color color = repoColor.ObtenerColor(vehiculo.Id_color);

                    vehiculo_encontrado.IdVehiculo = id_vehiculo;
                    vehiculo_encontrado.Matricula = vehiculo.Matricula;
                    vehiculo_encontrado.Marca = marca;
                    vehiculo_encontrado.Color = color;
                    vehiculo_encontrado.Modelo = vehiculo.Modelo;

                    repoVehiculo.EditarVehiculo(id_vehiculo, vehiculo_encontrado);
                }
            }
            catch(Exception e)
            {
                throw new Exception("Descripcion del error:", e);
            }
        }

        public void EliminarVehiculo(int id_vehiculo)
        {
            try
            {
                RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(_context);
                if(id_vehiculo != 0)
                {
                    repoVehiculo.EliminarVehiculo(id_vehiculo);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Descripcion del error:", e);
            }
        }

        public Vehiculo ObtenerVehiculoPorId(int id_vehiculo)
        {
            RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(_context);
            return repoVehiculo.ObtenerVehiculoPorId(id_vehiculo);
        }
    }
}
