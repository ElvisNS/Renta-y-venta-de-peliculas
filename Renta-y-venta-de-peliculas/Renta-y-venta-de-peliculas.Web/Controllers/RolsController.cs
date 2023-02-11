using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class RolsController : Controller
    {
        // GET: RolsController
        public ActionResult Index()
        {
            List<Models.RolsModel> Rol = new List<Models.RolsModel>()
            {
             //si el sn_activo esta en 1 significa que este mismo esta activo y si tiene un 0 es que esta inactivo

                new Models.RolsModel() 
                { 
                    cod_rol = 31, sn_activo= 1, txt_desc="Actor"
                },
                new Models.RolsModel() 
                {
                    cod_rol = 50, sn_activo= 0, txt_desc="Actor"
                },
                new Models.RolsModel() 
                {
                    cod_rol = 12, sn_activo= 1, txt_desc="Actor"
                },
                new Models.RolsModel() 
                {
                    cod_rol = 155, sn_activo= 0, txt_desc="Actor"
                }
            };
            return View(Rol);
        }

        // GET: RolsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RolsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolsController/Edit/5
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

        // GET: RolsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolsController/Delete/5
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
