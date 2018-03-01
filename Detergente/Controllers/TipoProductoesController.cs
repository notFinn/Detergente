using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Detergente.Models;
using Detergente.Models.Entity;

namespace Detergente.Controllers
{
    public class TipoProductoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoProductoes
        public ActionResult Index()
        {
            var tipoProducto = db.TipoProducto.Include(t => t.FamiliaTipoArticulo);
            return View(tipoProducto.ToList());
        }

        // GET: TipoProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProducto tipoProducto = db.TipoProducto.Find(id);
            if (tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProducto);
        }

        // GET: TipoProductoes/Create
        public ActionResult Create()
        {
            ViewBag.IdFamilia = new SelectList(db.FamiliaTipoArticulo, "Id", "NombreFamilia");
            return View();
        }

        // POST: TipoProductoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreTipo,IdFamilia")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                db.TipoProducto.Add(tipoProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFamilia = new SelectList(db.FamiliaTipoArticulo, "Id", "NombreFamilia", tipoProducto.IdFamilia);
            return View(tipoProducto);
        }

        // GET: TipoProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProducto tipoProducto = db.TipoProducto.Find(id);
            if (tipoProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFamilia = new SelectList(db.FamiliaTipoArticulo, "Id", "NombreFamilia", tipoProducto.IdFamilia);
            return View(tipoProducto);
        }

        // POST: TipoProductoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreTipo,IdFamilia")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFamilia = new SelectList(db.FamiliaTipoArticulo, "Id", "NombreFamilia", tipoProducto.IdFamilia);
            return View(tipoProducto);
        }

        // GET: TipoProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProducto tipoProducto = db.TipoProducto.Find(id);
            if (tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProducto);
        }

        // POST: TipoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoProducto tipoProducto = db.TipoProducto.Find(id);
            db.TipoProducto.Remove(tipoProducto);
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
