using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ahorro_PrestamosFinal.Models;

namespace Ahorro_PrestamosFinal.Controllers
{
    public class CUOTAS_PRESTAMOController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: CUOTAS_PRESTAMO
        public ActionResult Index()
        {
            var cUOTAS_PRESTAMO = db.CUOTAS_PRESTAMO.Include(c => c.PRESTAMOS);
            return View(cUOTAS_PRESTAMO.ToList());
        }





    // GET: CUOTAS_PRESTAMO/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUOTAS_PRESTAMO cUOTAS_PRESTAMO = db.CUOTAS_PRESTAMO.Find(id);
            if (cUOTAS_PRESTAMO == null)
            {
                return HttpNotFound();
            }
            return View(cUOTAS_PRESTAMO);
        }

        // GET: CUOTAS_PRESTAMO/Create
        public ActionResult Create()
        {
            ViewBag.id_prestamo = new SelectList(db.PRESTAMOS, "id_prestamo", "id_prestamo");
            return View();
        }

        // POST: CUOTAS_PRESTAMO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuota,Cuotas,fecha_planificada_pago,Cuota_Mensual,Intereses,Monto_Pagado,Deuda_Capital,fecha_efectiva_pago,Abono,modalidad_pago,id_prestamo")] CUOTAS_PRESTAMO cUOTAS_PRESTAMO)
        {
            if (ModelState.IsValid)
            {
                var prestamo = db.PRESTAMOS.Where(x => x.id_prestamo == cUOTAS_PRESTAMO.id_prestamo).FirstOrDefault();
                var TazaInteres = prestamo.tasa_interes;
                var MontoPrestamo = prestamo.monto_prestamo;
                var plazoPago = prestamo.Tiempo_Amortizacion_Meses;
                var fecha = DateTime.Now.Date.ToString();
                
                


                var id = prestamo.id_prestamo;

                var pago = db.CUOTAS_PRESTAMO.Where(x => x.id_prestamo == id).OrderByDescending(p => p.id_prestamo).FirstOrDefault();

                //int abono;

                double DeudaPrestamo = 0;
                double PrestamoInicial = 0;
                int cuotas = 0;
                int cuotasencontrada=0;


                if (pago != null)
                {
                    //DeudaPrestamo = (double)prestamo.monto_prestamo;
                    DeudaPrestamo = (double)pago.Deuda_Capital;
                    PrestamoInicial = DeudaPrestamo;
                    cuotasencontrada = (int)(pago.Cuotas);
                    cuotas = cuotasencontrada + 1;
                    //abono = (int)pago.Monto_Pagado;
                }
                else
                {
                    DeudaPrestamo = (double)MontoPrestamo;
                    PrestamoInicial = (double)MontoPrestamo;
                    cuotas = 1;
                }

                CUOTAS_PRESTAMO pagos = new CUOTAS_PRESTAMO();
                TazaInteres = Math.Round((double)(TazaInteres / 100),2);
                var interes = Math.Round((double)((double)(DeudaPrestamo * TazaInteres)/ plazoPago),2);
                //var cuotaMensual = interes / plazoPago;
                double montoPagado = (double)cUOTAS_PRESTAMO.Monto_Pagado;

                double montoPagadof = (double)cUOTAS_PRESTAMO.Monto_Pagado;//para capturar el valor del pago sin calculo
                var modoPago = cUOTAS_PRESTAMO.modalidad_pago;

                //double abonoPrestamo = 0;

                //if (abono > cuotaMensual)
                //{
                // abonoPrestamo = (double)(abono - cuotaMensual);
                //}
                //else
                //{
                // abonoPrestamo = 0;
                //}

                // pagos.fecha_planificada_pago = DateTime.Today.Date;
                pagos.Cuotas = plazoPago;

                //pagos.fecha_planificada_pago = DateTime.Today.Date;
                //pagos.Cuota_Mensual = cuotaMensual;
                pagos.Intereses = interes;

                var abono =Math.Round((double)(cUOTAS_PRESTAMO.Monto_Pagado - interes),2);
                pagos.Monto_Pagado = abono;
                // pagos.Abono = abono;
                pagos.Deuda_Capital =Math.Round((DeudaPrestamo - abono),2);
                //pago.fecha_efectiva_pago = DateTime.Today.Date;
                //pago.Abono = 0;
                pagos.modalidad_pago = modoPago;
                pagos.id_prestamo = id;
                pagos.fecha_efectiva_pago = Convert.ToDateTime(fecha);
                pagos.Cuotas = cuotas;
              
              
               pagos.Cuota_Mensual = montoPagadof;

                db.CUOTAS_PRESTAMO.Add(pagos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_prestamo = new SelectList(db.PRESTAMOS, "id_prestamo", "id_prestamo", cUOTAS_PRESTAMO.id_prestamo);
            return View(cUOTAS_PRESTAMO);
        }



        // GET: CUOTAS_PRESTAMO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUOTAS_PRESTAMO cUOTAS_PRESTAMO = db.CUOTAS_PRESTAMO.Find(id);
            if (cUOTAS_PRESTAMO == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_prestamo = new SelectList(db.PRESTAMOS, "id_prestamo", "id_prestamo", cUOTAS_PRESTAMO.id_prestamo);
            return View(cUOTAS_PRESTAMO);
        }

        // POST: CUOTAS_PRESTAMO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuota,Cuotas,fecha_planificada_pago,Cuota_Mensual,Intereses,Monto_Pagado,Deuda_Capital,fecha_efectiva_pago,Abono,modalidad_pago,id_prestamo")] CUOTAS_PRESTAMO cUOTAS_PRESTAMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUOTAS_PRESTAMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_prestamo = new SelectList(db.PRESTAMOS, "id_prestamo", "id_prestamo", cUOTAS_PRESTAMO.id_prestamo);
            return View(cUOTAS_PRESTAMO);
        }

        // GET: CUOTAS_PRESTAMO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUOTAS_PRESTAMO cUOTAS_PRESTAMO = db.CUOTAS_PRESTAMO.Find(id);
            if (cUOTAS_PRESTAMO == null)
            {
                return HttpNotFound();
            }
            return View(cUOTAS_PRESTAMO);
        }

        // POST: CUOTAS_PRESTAMO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUOTAS_PRESTAMO cUOTAS_PRESTAMO = db.CUOTAS_PRESTAMO.Find(id);
            db.CUOTAS_PRESTAMO.Remove(cUOTAS_PRESTAMO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
