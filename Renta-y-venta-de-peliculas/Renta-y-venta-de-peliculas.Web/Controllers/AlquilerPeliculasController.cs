using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renta_y_venta_de_peliculas.Web.Models;
using System.Collections.Generic;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class AlquilerPeliculasController : Controller
    {
        // GET: AlquilerPeliculasController
        public ActionResult Index()
        {
            List < Models.AlquilerPeliculasModel> APeliculas = new List<Models.AlquilerPeliculasModel>()
            {
                new Models.AlquilerPeliculasModel()
                {
                    Id=1,
                    cod_pelicula=321,cod_usuario=21, precio=149.99m, fecha=new DateTime(2022,09,03),  devuelta=false, fecha_devolucion=new DateTime(2022,09,15), cod_usuario_devolucion=21
                },
                new Models.AlquilerPeliculasModel()
                {
                    Id=2, cod_pelicula=345, cod_usuario=35, precio=199.99m, fecha=new DateTime(2023,01,06),  devuelta=true, fecha_devolucion=new DateTime(2023,01,25), cod_usuario_devolucion=35
                },
                new Models.AlquilerPeliculasModel()
                {
                    Id=3, cod_pelicula=467, cod_usuario=12, precio=459.99m, fecha=new DateTime(2022,06,20),  devuelta=false, fecha_devolucion=new DateTime(2022,07,10), cod_usuario_devolucion=12
                },
                new Models.AlquilerPeliculasModel()
                {
                    Id=4, cod_pelicula=982, cod_usuario=56, precio=239.99m, fecha=new DateTime(2022,12,13),  devuelta=true, fecha_devolucion=new DateTime(2023,01,15), cod_usuario_devolucion=56
                }
            };


            return View(APeliculas);
        }

        // GET: AlquilerPeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlquilerPeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlquilerPeliculasController/Create
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

        // GET: AlquilerPeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlquilerPeliculasController/Edit/5
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

        // GET: AlquilerPeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlquilerPeliculasController/Delete/5
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
