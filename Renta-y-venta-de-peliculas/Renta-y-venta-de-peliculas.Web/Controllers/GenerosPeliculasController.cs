using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class GenerosPeliculasController : Controller
    {
        // GET: GenerosPeliculasController
        public ActionResult Index()
        {
            List<Models.GenerosPeliculas> Gpeliculas = new List<Models.GenerosPeliculas>()
            {
                new Models.GenerosPeliculas() 
                {
                    cod_genero=12,cod_pelicula=109
                },
                new Models.GenerosPeliculas() 
                {
                    cod_genero=14,cod_pelicula=29
                },
                new Models.GenerosPeliculas() 
                {
                    cod_genero=10,cod_pelicula=160
                },
                new Models.GenerosPeliculas() 
                {
                    cod_genero=18,cod_pelicula=139
                }
            };
            return View(Gpeliculas);
        }

        // GET: GenerosPeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenerosPeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenerosPeliculasController/Create
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

        // GET: GenerosPeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenerosPeliculasController/Edit/5
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

        // GET: GenerosPeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenerosPeliculasController/Delete/5
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
