using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class VentaPeliculasController : Controller
    {
        // GET: VentaPeliculasController
        public ActionResult Index()
        {
            List<Models.VentaPeliculasModel> VPeliculas = new List<Models.VentaPeliculasModel>() 
            { 
                new Models.VentaPeliculasModel() 
                {
                    Id= 1,cod_usuario=01, cod_pelicula=08, precio=8786, fecha = new DateTime(2023, 2, 10)
                },
                new Models.VentaPeliculasModel()
                {
                    Id= 2,cod_usuario=09, cod_pelicula=02, precio=250, fecha = new DateTime(2023, 7, 10)
                },
                new Models.VentaPeliculasModel()
                {
                    Id= 3,cod_usuario=06, cod_pelicula=03, precio=300, fecha = new DateTime(2023, 8, 10)
                },
                new Models.VentaPeliculasModel()
                {
                    Id= 4,cod_usuario=05, cod_pelicula=05, precio=150, fecha = new DateTime(2023, 6, 10)
                }
            };
            return View(VPeliculas);
        }

        // GET: VentaPeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VentaPeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VentaPeliculasController/Create
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

        // GET: VentaPeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VentaPeliculasController/Edit/5
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

        // GET: VentaPeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentaPeliculasController/Delete/5
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
