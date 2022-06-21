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
    public class PRESTAMOSController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: PRESTAMOS
        public ActionResult Index()
        {
            var pRESTAMOS = db.PRESTAMOS.Include(p => p.CLIENTES).Include(p => p.CLIENTES1).Include(p => p.GARANTIA);
            return View(pRESTAMOS.ToList());
        }

        // GET: PRESTAMOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESTAMOS pRESTAMOS = db.PRESTAMOS.Find(id);
            if (pRESTAMOS == null)
            {
                return HttpNotFound();
            }
            return View(pRESTAMOS);
        }

        // GET: PRESTAMOS/Create
        public ActionResult Create()
        {
            ViewBag.cliente_prestatario = new SelectList(db.CLIENTES, "id_cliente", "cedula");
            ViewBag.cliente_fiador = new SelectList(db.CLIENTES, "id_cliente", "cedula");
            ViewBag.id_garantia = new SelectList(db.GARANTIA, "id_garantia", "tipo_garantia");
            return View();
        }

        // POST: PRESTAMOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prestamo,cliente_prestatario,cliente_fiador,fecha_solicitud_prestamo,fecha_aprobacion,fecha_inicio,fecha_termino,monto_prestamo,tasa_interes,Tiempo_Amortizacion_Meses,Total_Prestamo,aprovado,id_garantia")] PRESTAMOS pRESTAMOS)
        {
            if (ModelState.IsValid)
            {
                db.PRESTAMOS.Add(pRESTAMOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliente_prestatario = new SelectList(db.CLIENTES, "id_cliente", "cedula", pRESTAMOS.cliente_prestatario);
            ViewBag.cliente_fiador = new SelectList(db.CLIENTES, "id_cliente", "cedula", pRESTAMOS.cliente_fiador);
            ViewBag.id_garantia = new SelectList(db.GARANTIA, "id_garantia", "tipo_garantia", pRESTAMOS.id_garantia);
            return View(pRESTAMOS);
        }

        // GET: PRESTAMOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESTAMOS pRESTAMOS = db.PRESTAMOS.Find(id);
            if (pRESTAMOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.cliente_prestatario = new SelectList(db.CLIENTES, "id_cliente", "cedula", pRESTAMOS.cliente_prestatario);
            ViewBag.cliente_fiador = new SelectList(db.CLIENTES, "id_cliente", "cedula", pRESTAMOS.cliente_fiador);
            ViewBag.id_garantia = new SelectList(db.GARANTIA, "id_garantia", "tipo_garantia", pRESTAMOS.id_garantia);
            return View(pRESTAMOS);
        }

        // POST: PRESTAMOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prestamo,cliente_prestatario,cliente_fiador,fecha_solicitud_prestamo,fecha_aprobacion,fecha_inicio,fecha_termino,monto_prestamo,tasa_interes,Tiempo_Amortizacion_Meses,Total_Prestamo,aprovado,id_garantia")] PRESTAMOS pRESTAMOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRESTAMOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cliente_prestatario = new SelectList(db.CLIENTES, "id_cliente", "cedula", pRESTAMOS.cliente_prestatario);
            ViewBag.cliente_fiador = new SelectList(db.CLIENTES, "id_cliente", "cedula", pRESTAMOS.cliente_fiador);
            ViewBag.id_garantia = new SelectList(db.GARANTIA, "id_garantia", "tipo_garantia", pRESTAMOS.id_garantia);
            return View(pRESTAMOS);
        }

        // GET: PRESTAMOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESTAMOS pRESTAMOS = db.PRESTAMOS.Find(id);
            if (pRESTAMOS == null)
            {
                return HttpNotFound();
            }
            return View(pRESTAMOS);
        }

        // POST: PRESTAMOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRESTAMOS pRESTAMOS = db.PRESTAMOS.Find(id);
            db.PRESTAMOS.Remove(pRESTAMOS);
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
