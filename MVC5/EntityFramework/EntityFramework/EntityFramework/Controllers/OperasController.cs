using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class OperasController : Controller
    {
        private OperyDB db = new OperyDB();

        // GET: Operas
        public ActionResult Index()
        {
            return View(db.Opery.ToList());
        }

        // GET: Operas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opera opera = db.Opery.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // GET: Operas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperaID,Nazwa,Rok,Kompozytor,Dlugosc")] Opera opera)
        {
            if (ModelState.IsValid)
            {
                db.Opery.Add(opera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opera);
        }

        // GET: Operas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opera opera = db.Opery.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // POST: Operas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperaID,Nazwa,Rok,Kompozytor,Dlugosc")] Opera opera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }

        // GET: Operas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opera opera = db.Opery.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // POST: Operas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = db.Opery.Find(id);
            db.Opery.Remove(opera);
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
