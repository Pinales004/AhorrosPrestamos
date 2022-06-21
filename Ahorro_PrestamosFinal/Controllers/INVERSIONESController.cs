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
    public class INVERSIONESController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: INVERSIONES
        public ActionResult Index()
        {
            var iNVERSIONES = db.INVERSIONES.Include(i => i.CLIENTES);
            return View(iNVERSIONES.ToList());
        }

        // GET: INVERSIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVERSIONES iNVERSIONES = db.INVERSIONES.Find(id);
            if (iNVERSIONES == null)
            {
                return HttpNotFound();
            }
            return View(iNVERSIONES);
        }

        // GET: INVERSIONES/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula");
            return View();
        }

        // POST: INVERSIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_inversion,monto_inversion,tipo_inversion_meses,tasa_inversion_interes,fecha_realizada_inversion,fecha_termino_inversion,vigente,id_cliente")] INVERSIONES iNVERSIONES)
        {
            if (ModelState.IsValid)
            {
                db.INVERSIONES.Add(iNVERSIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula", iNVERSIONES.id_cliente);
            return View(iNVERSIONES);
        }

        // GET: INVERSIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVERSIONES iNVERSIONES = db.INVERSIONES.Find(id);
            if (iNVERSIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula", iNVERSIONES.id_cliente);
            return View(iNVERSIONES);
        }

        // POST: INVERSIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_inversion,monto_inversion,tipo_inversion_meses,tasa_inversion_interes,fecha_realizada_inversion,fecha_termino_inversion,vigente,id_cliente")] INVERSIONES iNVERSIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVERSIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula", iNVERSIONES.id_cliente);
            return View(iNVERSIONES);
        }

        // GET: INVERSIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVERSIONES iNVERSIONES = db.INVERSIONES.Find(id);
            if (iNVERSIONES == null)
            {
                return HttpNotFound();
            }
            return View(iNVERSIONES);
        }

        // POST: INVERSIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVERSIONES iNVERSIONES = db.INVERSIONES.Find(id);
            db.INVERSIONES.Remove(iNVERSIONES);
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
