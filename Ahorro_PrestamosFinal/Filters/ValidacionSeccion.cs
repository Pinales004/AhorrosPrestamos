using Ahorro_PrestamosFinal.Models;
using Ahorro_PrestamosFinal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ahorro_PrestamosFinal.Filters
{
    public class ValidacionSeccion : ActionFilterAttribute
    {

        private USUARIOS oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                oUsuario = (USUARIOS)HttpContext.Current.Session["Usuario"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }

                }


            }
            catch (Exception ex)
            {
            }
        }
    }
}