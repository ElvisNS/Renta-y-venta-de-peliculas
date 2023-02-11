using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class GenerosController : Controller
    {
        // GET: GenerosController
        public ActionResult Index()
        {
            List<Models.GenerosModels> Generos = new List<Models.GenerosModels>()
            {
                new Models.GenerosModels
                {
                    cod_genero = 12, txt_desc="Terror"
                },
                new Models.GenerosModels
                {
                    cod_genero = 12, txt_desc="Accion"
                },
                new Models.GenerosModels
                {
                    cod_genero = 12, txt_desc="Romance"
                },
                new Models.GenerosModels
                {
                    cod_genero = 12,
                    txt_desc = "Ciencia Ficcion"
                }
            };
            return View(Generos);
        }

        // GET: GenerosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenerosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenerosController/Create
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

        // GET: GenerosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenerosController/Edit/5
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

        // GET: GenerosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenerosController/Delete/5
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
