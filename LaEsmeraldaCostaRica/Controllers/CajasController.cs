using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaEsmeraldaCostaRica.Models;

namespace LaEsmeraldaCostaRica.Controllers
{
    [Authorize]
    public class CajasController : Controller
    {
        private InventariosCamaras db = new InventariosCamaras();

        // GET: Cajas
        public ActionResult Index()
        {
            return View(db.Cajas.ToList());
        }

        // GET: Cajas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caja caja = db.Cajas.Find(id);
            if (caja == null)
            {
                return HttpNotFound();
            }
            return View(caja);
        }

        // GET: Cajas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cajas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,descripcion")] Caja caja)
        {
            if (ModelState.IsValid)
            {
                db.Cajas.Add(caja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caja);
        }

        // GET: Cajas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caja caja = db.Cajas.Find(id);
            if (caja == null)
            {
                return HttpNotFound();
            }
            return View(caja);
        }

        // POST: Cajas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,descripcion")] Caja caja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caja);
        }

        // GET: Cajas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caja caja = db.Cajas.Find(id);
            if (caja == null)
            {
                return HttpNotFound();
            }
            return View(caja);
        }

        // POST: Cajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caja caja = db.Cajas.Find(id);
            db.Cajas.Remove(caja);
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
