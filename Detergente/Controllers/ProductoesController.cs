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
    public class ProductoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Productoes
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.TipoProducto);
            return View(producto.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "Id", "NombreTipo");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Cantidad,Precio,IdTipoProducto,FechaIngreso,Disponible")] Producto producto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                          + file.FileName);
                    producto.ImagePath = file.FileName;
                }
                db.Producto.Add(producto);

                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "Id", "NombreTipo", producto.IdTipoProducto);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "Id", "NombreTipo", producto.IdTipoProducto);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Cantidad,Precio,IdTipoProducto,FechaActualizacion,ImagePath,Disponible")] Producto producto, HttpPostedFileBase file)
        {
            if (file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                      + file.FileName);
                producto.ImagePath = file.FileName;
            }
            db.Producto.Add(producto);
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoProducto = new SelectList(db.TipoProducto, "Id", "NombreTipo", producto.IdTipoProducto);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
        public ActionResult ListadoProductos3() {

            var producto = db.Producto.Include(p => p.TipoProducto);
            return View(producto.ToList());
        }
    }
}
