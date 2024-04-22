using AccesoDatos.DataContext;
using LogicaApp;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ClasesCustom;

namespace ApiTallerMecanico.Controllers
{
    public class ServicioController : Controller
    {
        private readonly TallerMecanicoContext _context;

        public ServicioController(TallerMecanicoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista-servicio")]
        public List<Servicio> Index()
        {
            LogicaServicio logicaServicio = new LogicaServicio(_context);
            return logicaServicio.ListarServicios();
        }

        [HttpGet]
        [Route("detalle-servicio")]
        public Servicio Details(int id)
        {
            LogicaServicio logicaServicio= new LogicaServicio(_context);
            return logicaServicio.ObtenerServicioPorId(id);
        }

        // GET: ServicioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioController/Create
        [HttpPost]
        [Route("crear-servicio")]
        public void Create(CrearServicio servicio)
        {
            try
            {
                LogicaServicio logicaServicio= new LogicaServicio(_context);
                logicaServicio.CrearServicio(servicio);
            }
            catch
            {
                StatusCode(400);
            }
        }

        // GET: ServicioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicioController/Edit/5
        [HttpPost]
        [Route("editar-servicio")]
        public void Edit(int id, CrearServicio servicio)
        {
            try
            {
                LogicaServicio logicaServicio = new LogicaServicio(_context);
                logicaServicio.EditarServicio(id, servicio);
            }
            catch
            {
                StatusCode(400);
            }
        }

        // GET: ServicioController/Delete/5
        [HttpGet]
        [Route("eliminar-servicio")]
        public void Delete(int id)
        {
            LogicaServicio logicaServicio = new LogicaServicio(_context);
            logicaServicio.EliminarServicio(id);
        }

        // POST: ServicioController/Delete/5
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
