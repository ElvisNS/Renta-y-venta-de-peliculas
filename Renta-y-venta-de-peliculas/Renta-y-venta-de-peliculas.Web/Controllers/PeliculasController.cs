using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class PeliculasController : Controller

    {
        // GET: PeliculasController
        public ActionResult Index()
        {

            List<Models.PeliculasModel> Peliculas = new List<Models.PeliculasModel>()
            {
                new Models.PeliculasModel()
                {
                    cod_pelicula=210234, cant_disponibles_alquiler= 40, cant_disponibles_venta= 150, precio_alquiler=300.00M, precio_venta=500.00M , txt_desc = " Viaje en el tiempo a 10 decadas atrás"
                },
                new Models.PeliculasModel()
                {
                    cod_pelicula = 210546, cant_disponibles_alquiler = 30, cant_disponibles_venta = 143, precio_alquiler = 300.00M , precio_venta = 500.00M, txt_desc = " Las dificultades de trabajar en la industria del entretenimiento"
                },
                new Models.PeliculasModel()
                {
                     cod_pelicula =921046, cant_disponibles_alquiler =50, cant_disponibles_venta =113, precio_alquiler =435.00M , precio_venta =600.00M, txt_desc = " Adaptación del famoso libro de la literatura francesa EL PRINCIPITO"
                },
                new Models.PeliculasModel()
                {
                     cod_pelicula =945478,cant_disponibles_alquiler =48,cant_disponibles_venta =182,precio_alquiler =435.00M , precio_venta =600.00M, txt_desc = " Clásico de Disney Blancanieves"
                }
            };
            return View(Peliculas);
        }

        // GET: PeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculasController/Create
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

        // GET: PeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculasController/Edit/5
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

        // GET: PeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeliculasController/Delete/5
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
