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
    public class GARANTIAsController : Controller
    {
        private AhorrosPrestamosEntities db = new AhorrosPrestamosEntities();

        // GET: GARANTIAs
        public ActionResult Index()
        {
            return View(db.GARANTIA.ToList());
        }

        // GET: GARANTIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GARANTIA gARANTIA = db.GARANTIA.Find(id);
            if (gARANTIA == null)
            {
                return HttpNotFound();
            }
            return View(gARANTIA);
        }

        // GET: GARANTIAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GARANTIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_garantia,codigo_garantia,tipo_garantia,descripcion,valor_garantia,ubicacion_garantia")] GARANTIA gARANTIA)
        {
            if (ModelState.IsValid)
            {
                db.GARANTIA.Add(gARANTIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gARANTIA);
        }

        // GET: GARANTIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GARANTIA gARANTIA = db.GARANTIA.Find(id);
            if (gARANTIA == null)
            {
                return HttpNotFound();
            }
            return View(gARANTIA);
        }

        // POST: GARANTIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_garantia,codigo_garantia,tipo_garantia,descripcion,valor_garantia,ubicacion_garantia")] GARANTIA gARANTIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gARANTIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gARANTIA);
        }

        // GET: GARANTIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GARANTIA gARANTIA = db.GARANTIA.Find(id);
            if (gARANTIA == null)
            {
                return HttpNotFound();
            }
            return View(gARANTIA);
        }

        // POST: GARANTIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GARANTIA gARANTIA = db.GARANTIA.Find(id);
            db.GARANTIA.Remove(gARANTIA);
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
