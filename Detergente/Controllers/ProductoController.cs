using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Detergente.Metodos;
using Detergente.Models;
using Models;
using Persistence;

namespace Detergente.Controllers
{
    public class ProductoController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        private string sessionValue;

        // GET: Productoes
        public ActionResult Index()
        {

            var producto = db.Producto.Include(p => p.TipoProducto);
            var TipoPro = db.TipoProducto.OrderBy(q => q.NombreTipo).ToList();
            ViewBag.SelectTipo = new SelectList(TipoPro, "Id", "NombreTipo");

            return View(producto.ToList());
        }
        [HttpPost]
        public ActionResult Index(int? SelectTipo)
        {
            if (SelectTipo == null)
            {
                var producto = db.Producto.Include(p => p.TipoProducto);
                var TipoPro = db.TipoProducto.OrderBy(q => q.NombreTipo).ToList();
                ViewBag.SelectTipo = new SelectList(TipoPro, "Id", "NombreTipo", SelectTipo);
                int tipoId = SelectTipo.GetValueOrDefault();
                return View(producto.ToList());
            }
            else {
                var TipoPro = db.TipoProducto.OrderBy(q => q.NombreTipo).ToList();
                ViewBag.SelectTipo = new SelectList(TipoPro, "Id", "NombreTipo", SelectTipo);
                int tipoId = SelectTipo.GetValueOrDefault();

                IQueryable<Producto> producto = db.Producto
                    .Where(t => !SelectTipo.HasValue || t.IdTipoProducto == tipoId)
                    .OrderBy(p => p.Id)
                    .Include(p => p.TipoProducto);
                var sql = producto.ToString();

                return View(producto.ToList());
            }
            
            
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
        public ActionResult ListaProductos() {

            var producto = db.Producto.Include(p => p.TipoProducto);
            return View(producto.ToList());
        }

        [HttpGet]
        public ActionResult Agregar(Producto producto, int Id,int? Precio)
        {
            sessionValue = (String)System.Web.HttpContext.Current.Session["Carrito"];
            //var se = Session.SessionID;
            string json = AgregarCarro.Agregar(producto, sessionValue);

            System.Web.HttpContext.Current.Session["Carrito"] = json;
            return RedirectToAction("ListaProductos");
        }
    }
}
