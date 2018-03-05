using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Models;
using Persistence;

namespace Detergente.Controllers
{
    public class FamiliaTipoArticuloController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FamiliaTipoArticuloes
        
        public ActionResult Index()
        {
            return View(db.FamiliaTipoArticulo.ToList());
        }

        // GET: FamiliaTipoArticuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamiliaTipoArticulo familiaTipoArticulo = db.FamiliaTipoArticulo.Find(id);
            if (familiaTipoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(familiaTipoArticulo);
        }

        // GET: FamiliaTipoArticuloes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamiliaTipoArticuloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,NombreFamilia")] FamiliaTipoArticulo familiaTipoArticulo)
        {
            if (ModelState.IsValid)
            {
                db.FamiliaTipoArticulo.Add(familiaTipoArticulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familiaTipoArticulo);
        }

        // GET: FamiliaTipoArticuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamiliaTipoArticulo familiaTipoArticulo = db.FamiliaTipoArticulo.Find(id);
            if (familiaTipoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(familiaTipoArticulo);
        }

        // POST: FamiliaTipoArticuloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreFamilia")] FamiliaTipoArticulo familiaTipoArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familiaTipoArticulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familiaTipoArticulo);
        }

        // GET: FamiliaTipoArticuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamiliaTipoArticulo familiaTipoArticulo = db.FamiliaTipoArticulo.Find(id);
            if (familiaTipoArticulo == null)
            {
                return HttpNotFound();
            }
            return View(familiaTipoArticulo);
        }

        // POST: FamiliaTipoArticuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamiliaTipoArticulo familiaTipoArticulo = db.FamiliaTipoArticulo.Find(id);
            db.FamiliaTipoArticulo.Remove(familiaTipoArticulo);
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
