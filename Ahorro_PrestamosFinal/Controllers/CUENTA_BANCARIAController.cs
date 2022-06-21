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
    public class CUENTA_BANCARIAController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: CUENTA_BANCARIA
        public ActionResult Index()
        {
            var cUENTA_BANCARIA = db.CUENTA_BANCARIA.Include(c => c.CLIENTES);
            return View(cUENTA_BANCARIA.ToList());
        }

        // GET: CUENTA_BANCARIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA_BANCARIA cUENTA_BANCARIA = db.CUENTA_BANCARIA.Find(id);
            if (cUENTA_BANCARIA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA_BANCARIA);
        }

        // GET: CUENTA_BANCARIA/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula");
            return View();
        }

        // POST: CUENTA_BANCARIA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuenta,numero_cuenta,banco,tipo_cuenta,id_cliente")] CUENTA_BANCARIA cUENTA_BANCARIA)
        {
            if (ModelState.IsValid)
            {
                db.CUENTA_BANCARIA.Add(cUENTA_BANCARIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula", cUENTA_BANCARIA.id_cliente);
            return View(cUENTA_BANCARIA);
        }

        // GET: CUENTA_BANCARIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA_BANCARIA cUENTA_BANCARIA = db.CUENTA_BANCARIA.Find(id);
            if (cUENTA_BANCARIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula", cUENTA_BANCARIA.id_cliente);
            return View(cUENTA_BANCARIA);
        }

        // POST: CUENTA_BANCARIA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuenta,numero_cuenta,banco,tipo_cuenta,id_cliente")] CUENTA_BANCARIA cUENTA_BANCARIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUENTA_BANCARIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.CLIENTES, "id_cliente", "cedula", cUENTA_BANCARIA.id_cliente);
            return View(cUENTA_BANCARIA);
        }

        // GET: CUENTA_BANCARIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA_BANCARIA cUENTA_BANCARIA = db.CUENTA_BANCARIA.Find(id);
            if (cUENTA_BANCARIA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA_BANCARIA);
        }

        // POST: CUENTA_BANCARIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUENTA_BANCARIA cUENTA_BANCARIA = db.CUENTA_BANCARIA.Find(id);
            db.CUENTA_BANCARIA.Remove(cUENTA_BANCARIA);
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
