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
    public class INTERMEDIA_CLIENTE_ROLController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: INTERMEDIA_CLIENTE_ROL
        public ActionResult Index()
        {
            var iNTERMEDIA_CLIENTE_ROL = db.INTERMEDIA_CLIENTE_ROL.Include(i => i.CLIENTES).Include(i => i.ROL_CLIENTES);
            return View(iNTERMEDIA_CLIENTE_ROL.ToList());
        }

        // GET: INTERMEDIA_CLIENTE_ROL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INTERMEDIA_CLIENTE_ROL iNTERMEDIA_CLIENTE_ROL = db.INTERMEDIA_CLIENTE_ROL.Find(id);
            if (iNTERMEDIA_CLIENTE_ROL == null)
            {
                return HttpNotFound();
            }
            return View(iNTERMEDIA_CLIENTE_ROL);
        }

        // GET: INTERMEDIA_CLIENTE_ROL/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente_intermedia = new SelectList(db.CLIENTES, "id_cliente", "cedula");
            ViewBag.id_rol_cliente_intermedia = new SelectList(db.ROL_CLIENTES, "id_rol_cliente", "tipo_rol");
            return View();
        }

        // POST: INTERMEDIA_CLIENTE_ROL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_intermedia_cliente_rol,id_cliente_intermedia,id_rol_cliente_intermedia")] INTERMEDIA_CLIENTE_ROL iNTERMEDIA_CLIENTE_ROL)
        {
            if (ModelState.IsValid)
            {
                db.INTERMEDIA_CLIENTE_ROL.Add(iNTERMEDIA_CLIENTE_ROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente_intermedia = new SelectList(db.CLIENTES, "id_cliente", "cedula", iNTERMEDIA_CLIENTE_ROL.id_cliente_intermedia);
            ViewBag.id_rol_cliente_intermedia = new SelectList(db.ROL_CLIENTES, "id_rol_cliente", "tipo_rol", iNTERMEDIA_CLIENTE_ROL.id_rol_cliente_intermedia);
            return View(iNTERMEDIA_CLIENTE_ROL);
        }

        // GET: INTERMEDIA_CLIENTE_ROL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INTERMEDIA_CLIENTE_ROL iNTERMEDIA_CLIENTE_ROL = db.INTERMEDIA_CLIENTE_ROL.Find(id);
            if (iNTERMEDIA_CLIENTE_ROL == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente_intermedia = new SelectList(db.CLIENTES, "id_cliente", "cedula", iNTERMEDIA_CLIENTE_ROL.id_cliente_intermedia);
            ViewBag.id_rol_cliente_intermedia = new SelectList(db.ROL_CLIENTES, "id_rol_cliente", "tipo_rol", iNTERMEDIA_CLIENTE_ROL.id_rol_cliente_intermedia);
            return View(iNTERMEDIA_CLIENTE_ROL);
        }

        // POST: INTERMEDIA_CLIENTE_ROL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_intermedia_cliente_rol,id_cliente_intermedia,id_rol_cliente_intermedia")] INTERMEDIA_CLIENTE_ROL iNTERMEDIA_CLIENTE_ROL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNTERMEDIA_CLIENTE_ROL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente_intermedia = new SelectList(db.CLIENTES, "id_cliente", "cedula", iNTERMEDIA_CLIENTE_ROL.id_cliente_intermedia);
            ViewBag.id_rol_cliente_intermedia = new SelectList(db.ROL_CLIENTES, "id_rol_cliente", "tipo_rol", iNTERMEDIA_CLIENTE_ROL.id_rol_cliente_intermedia);
            return View(iNTERMEDIA_CLIENTE_ROL);
        }

        // GET: INTERMEDIA_CLIENTE_ROL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INTERMEDIA_CLIENTE_ROL iNTERMEDIA_CLIENTE_ROL = db.INTERMEDIA_CLIENTE_ROL.Find(id);
            if (iNTERMEDIA_CLIENTE_ROL == null)
            {
                return HttpNotFound();
            }
            return View(iNTERMEDIA_CLIENTE_ROL);
        }

        // POST: INTERMEDIA_CLIENTE_ROL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INTERMEDIA_CLIENTE_ROL iNTERMEDIA_CLIENTE_ROL = db.INTERMEDIA_CLIENTE_ROL.Find(id);
            db.INTERMEDIA_CLIENTE_ROL.Remove(iNTERMEDIA_CLIENTE_ROL);
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
