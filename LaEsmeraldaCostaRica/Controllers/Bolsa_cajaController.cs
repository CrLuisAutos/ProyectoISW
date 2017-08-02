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
    public class Bolsa_cajaController : Controller
    {
        private InventariosCamaras db = new InventariosCamaras();

        // GET: Bolsa_caja
        public ActionResult Index()
        {
            var bolsa_por_caja = db.Bolsa_por_caja.Include(b => b.Bolsa).Include(b => b.Caja).Include(b => b.Producto);
            return View(bolsa_por_caja.ToList());
        }

        // GET: Bolsa_caja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa_por_caja bolsa_por_caja = db.Bolsa_por_caja.Find(id);
            if (bolsa_por_caja == null)
            {
                return HttpNotFound();
            }
            return View(bolsa_por_caja);
        }

        // GET: Bolsa_caja/Create
        public ActionResult Create()
        {
            ViewBag.id_bolsa = new SelectList(db.Bolsas, "id", "codigo");
            ViewBag.id_caja = new SelectList(db.Cajas, "id", "codigo");
            ViewBag.id_producto = new SelectList(db.productoes, "id", "nombre");
            return View();
        }

        // POST: Bolsa_caja/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,id_bolsa,id_caja,id_producto,cantidad,fec_entrada,fech_vencimiento")] Bolsa_por_caja bolsa_por_caja)
        {
            if (ModelState.IsValid)
            {
                db.Bolsa_por_caja.Add(bolsa_por_caja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_bolsa = new SelectList(db.Bolsas, "id", "codigo", bolsa_por_caja.id_bolsa);
            ViewBag.id_caja = new SelectList(db.Cajas, "id", "codigo", bolsa_por_caja.id_caja);
            ViewBag.id_producto = new SelectList(db.productoes, "id", "nombre", bolsa_por_caja.id_producto);
            return View(bolsa_por_caja);
        }

        // GET: Bolsa_caja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa_por_caja bolsa_por_caja = db.Bolsa_por_caja.Find(id);
            if (bolsa_por_caja == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_bolsa = new SelectList(db.Bolsas, "id", "codigo", bolsa_por_caja.id_bolsa);
            ViewBag.id_caja = new SelectList(db.Cajas, "id", "codigo", bolsa_por_caja.id_caja);
            ViewBag.id_producto = new SelectList(db.productoes, "id", "nombre", bolsa_por_caja.id_producto);
            return View(bolsa_por_caja);
        }

        // POST: Bolsa_caja/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,id_bolsa,id_caja,id_producto,cantidad,fec_entrada,fech_vencimiento")] Bolsa_por_caja bolsa_por_caja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolsa_por_caja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_bolsa = new SelectList(db.Bolsas, "id", "codigo", bolsa_por_caja.id_bolsa);
            ViewBag.id_caja = new SelectList(db.Cajas, "id", "codigo", bolsa_por_caja.id_caja);
            ViewBag.id_producto = new SelectList(db.productoes, "id", "nombre", bolsa_por_caja.id_producto);
            return View(bolsa_por_caja);
        }

        // GET: Bolsa_caja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolsa_por_caja bolsa_por_caja = db.Bolsa_por_caja.Find(id);
            if (bolsa_por_caja == null)
            {
                return HttpNotFound();
            }
            return View(bolsa_por_caja);
        }

        // POST: Bolsa_caja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolsa_por_caja bolsa_por_caja = db.Bolsa_por_caja.Find(id);
            db.Bolsa_por_caja.Remove(bolsa_por_caja);
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
