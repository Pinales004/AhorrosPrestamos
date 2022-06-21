using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahorro_PrestamosFinal.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string Clave)
        {
            try
            {

                using (Models.AhorrosPrestamosEntities db = new Models.AhorrosPrestamosEntities())
                {

                    var ousuario = (from d in db.USUARIOS
                                    where d.usuario == Usuario.Trim() && d.clave == Clave.Trim()
                                    select d).FirstOrDefault();

                    if (ousuario == null)
                    {
                        ViewBag.Error = " Usuario o Clave Incorrectos";
                        return View();
                    }

                    Session["Usuario"] = ousuario;

                }

                return RedirectToAction("Index", "Home");


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;

            }
            return View();
        }

    }
}