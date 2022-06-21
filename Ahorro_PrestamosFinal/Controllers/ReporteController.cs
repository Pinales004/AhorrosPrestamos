using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ahorro_PrestamosFinal.Models;
using System.Data.Entity;

namespace Ahorro_PrestamosFinal.Controllers
{
    public class ReporteController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: Reporte
        public ActionResult Index(string dias_atraso)
        {
            ReporteAtraso reporte = new ReporteAtraso();
            
            if (!String.IsNullOrEmpty(dias_atraso))
            {
                //dividmimos en string en dos agrupandolas en un arreglo y luego asignandole una posicion
                //asignamos en variables enteras
                string[] split = dias_atraso.Split('-');
                int inicio= int.Parse(split[0]);
                int fin= int.Parse(split[1]);
                //selecionamos la tabla reporte
                var id_mora = from s in db.ReporteAtraso select s;
                //filtramos y asignamos la variables para un rango de busqueda
                var mora_atraso = db.ReporteAtraso.Where(x => x.dias_atraso >=inicio && x.dias_atraso <=fin);

                //Diasatraso = Convert.ToInt32(dias_atraso);
                //var Moras = from s in db.ReporteAtraso select s;
                //Moras = Moras.Where(x => x.dias_atraso == Diasatraso);
                return View(mora_atraso);

            }
            else
            {
                var moras = db.ReporteAtraso.Include(c => c.CUOTAS_PRESTAMO);
                return View(moras.ToList());
            }
        }
    }
}