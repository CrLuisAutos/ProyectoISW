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
    public class BolsasController : Controller
    {
        private InventariosCamaras db = new InventariosCamaras();

        // GET: Bolsas
        public ActionResult Index()
        {
            return View(db.Bolsas.ToList());
        }

        // GET: Bolsas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa bolsa = db.Bolsas.Find(id);
            if (bolsa == null)
            {
                return HttpNotFound();
            }
            return View(bolsa);
        }

        // GET: Bolsas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bolsas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,descripcion")] Bolsa bolsa)
        {
            if (ModelState.IsValid)
            {
                db.Bolsas.Add(bolsa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bolsa);
        }

        // GET: Bolsas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa bolsa = db.Bolsas.Find(id);
            if (bolsa == null)
            {
                return HttpNotFound();
            }
            return View(bolsa);
        }

        // POST: Bolsas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,descripcion")] Bolsa bolsa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolsa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolsa);
        }

        // GET: Bolsas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa bolsa = db.Bolsas.Find(id);
            if (bolsa == null)
            {
                return HttpNotFound();
            }
            return View(bolsa);
        }

        // POST: Bolsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolsa bolsa = db.Bolsas.Find(id);
            db.Bolsas.Remove(bolsa);
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
