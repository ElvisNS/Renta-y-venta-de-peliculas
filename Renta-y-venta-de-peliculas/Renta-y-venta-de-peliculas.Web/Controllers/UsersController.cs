using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Renta_y_venta_de_peliculas.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: UsersController
        public ActionResult Index()
        {
            List<Models.UsersModel> Users = new List<Models.UsersModel>()
            {
                // si el usuario esta activo se representara como 1 y si esta inactivo se representara como 0
                new Models.UsersModel()
                {
                    txt_nombre="Elvis", txt_apellido="Núñez ", txt_user="ElvisNS", txt_password="Elvis9181", cod_usuario= 01, cod_rol=323, sn_activo=1   
                },
                  new Models.UsersModel()
                {
                    txt_nombre="Martin", txt_apellido="Pimentel", txt_user="MartinPM", txt_password="Martin0132", cod_usuario= 02, cod_rol=544, sn_activo=1

                },  new Models.UsersModel()
                {
                    txt_nombre="Jose", txt_apellido="De la Cruz", txt_user="JoseDC", txt_password="Jose123", cod_usuario= 03, cod_rol=123, sn_activo=0

                },  new Models.UsersModel()
                {
                    txt_nombre="Leonys", txt_apellido="Vasquez", txt_user="LeonysVZ", txt_password="Leonys9877", cod_usuario= 04, cod_rol=323, sn_activo=1

                }, 
            };
            return View(Users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
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

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
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

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
