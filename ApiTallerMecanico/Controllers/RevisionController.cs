using AccesoDatos.DataContext;
using LogicaApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.ClasesCustom;

namespace ApiTallerMecanico.Controllers
{
    public class RevisionController : Controller
    {

        private readonly TallerMecanicoContext _context;

        public RevisionController(TallerMecanicoContext context)
        {
            _context = context;
        }

        // GET: RevisionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RevisionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RevisionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RevisionController/Create
        [HttpPost]
        [Route("crear-revision")]
        public void Create(CrearRevision item_revision)
        {
            try
            {
                LogicaRevision logicaRevision = new LogicaRevision(_context);
                logicaRevision.CrearRevision(item_revision);
            }
            catch
            {

            }
        }

        // GET: RevisionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RevisionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: RevisionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RevisionController/Delete/5
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
