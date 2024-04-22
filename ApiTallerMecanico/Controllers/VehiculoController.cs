using AccesoDatos.DataContext;
using LogicaApp;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ClasesCustom;

namespace ApiTallerMecanico.Controllers
{
    public class VehiculoController : Controller
    {

        private readonly TallerMecanicoContext _context;

        public VehiculoController(TallerMecanicoContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("lista-vehiculo")]
        public List<Vehiculo> Index()
        //Lista todos los vehiculos que existen en la base de datos.
        {
            LogicaVehiculo logicaVehiculo = new LogicaVehiculo(_context);
            return logicaVehiculo.ListarVehiculos();
        }

        [HttpGet]
        [Route("detalle-vehiculo")]
        public Vehiculo Details(int id)
        //Obtiene el detalle de un vehiculo, buscandolo por la id.
        {
            LogicaVehiculo logicaVehiculo = new LogicaVehiculo(_context);
            return logicaVehiculo.ObtenerVehiculoPorId(id);
        }

        // GET: VehiculoController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("crear-vehiculo")]
        public void Create(CrearVehiculo vehiculo)
        //Crea un objeto Vehiculo en la base de datos.
        {
            try
            {
                LogicaVehiculo logicaVehiculo = new LogicaVehiculo(_context);
                logicaVehiculo.CrearVehiculo(vehiculo);
            }
            catch
            {
                StatusCode(400);
            }
        }

        [HttpPost]
        [Route("editar-vehiculo")]
        public void Edit(int id, CrearVehiculo vehiculo)
        //Edita un objeto Vehiculo en la base de datos por su id.
        {
            try
            {
                LogicaVehiculo logicaVehiculo = new LogicaVehiculo(_context);
                logicaVehiculo.EditarVehiculo(id, vehiculo);
            }
            catch
            {
                StatusCode(400);
            }
        }

        [HttpGet]
        [Route("eliminar-vehiculo")]
        public void Delete(int id)
        //Elimina un objeto Vehiculo en la base de datos por su id.
        {
            LogicaVehiculo logicaVehiculo = new LogicaVehiculo(_context);
            logicaVehiculo.EliminarVehiculo(id);
        }

        // POST: VehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
