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
    public class PAGO_INVERSIONController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: PAGO_INVERSION
        public ActionResult Index()
        {
            var pAGO_INVERSION = db.PAGO_INVERSION.Include(p => p.INVERSIONES);
            return View(pAGO_INVERSION.ToList());
        }

        // GET: PAGO_INVERSION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO_INVERSION pAGO_INVERSION = db.PAGO_INVERSION.Find(id);
            if (pAGO_INVERSION == null)
            {
                return HttpNotFound();
            }
            return View(pAGO_INVERSION);
        }

        // GET: PAGO_INVERSION/Create
        public ActionResult Create()
        {
            ViewBag.id_inversion = new SelectList(db.INVERSIONES, "id_inversion", "id_inversion");
            return View();
        }

        // POST: PAGO_INVERSION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuota_inversion,fecha_planificada_pago,fecha_efectiva_pago,Monto_Pagado,modalidad_pago,comprobante_pago,id_inversion")] PAGO_INVERSION pAGO_INVERSION)
        {
            if (ModelState.IsValid)
            {
                db.PAGO_INVERSION.Add(pAGO_INVERSION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inversion = new SelectList(db.INVERSIONES, "id_inversion", "id_inversion", pAGO_INVERSION.id_inversion);
            return View(pAGO_INVERSION);
        }

        // GET: PAGO_INVERSION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO_INVERSION pAGO_INVERSION = db.PAGO_INVERSION.Find(id);
            if (pAGO_INVERSION == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inversion = new SelectList(db.INVERSIONES, "id_inversion", "id_inversion", pAGO_INVERSION.id_inversion);
            return View(pAGO_INVERSION);
        }

        // POST: PAGO_INVERSION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuota_inversion,fecha_planificada_pago,fecha_efectiva_pago,Monto_Pagado,modalidad_pago,comprobante_pago,id_inversion")] PAGO_INVERSION pAGO_INVERSION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAGO_INVERSION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inversion = new SelectList(db.INVERSIONES, "id_inversion", "id_inversion", pAGO_INVERSION.id_inversion);
            return View(pAGO_INVERSION);
        }

        // GET: PAGO_INVERSION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO_INVERSION pAGO_INVERSION = db.PAGO_INVERSION.Find(id);
            if (pAGO_INVERSION == null)
            {
                return HttpNotFound();
            }
            return View(pAGO_INVERSION);
        }

        // POST: PAGO_INVERSION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAGO_INVERSION pAGO_INVERSION = db.PAGO_INVERSION.Find(id);
            db.PAGO_INVERSION.Remove(pAGO_INVERSION);
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
