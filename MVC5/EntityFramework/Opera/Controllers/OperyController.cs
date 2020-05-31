using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Opera.Models;

namespace Opera.Controllers
{
    public class OperyController : Controller
    {
        private OperyDB db = new OperyDB();

        // GET: Opery
        public ActionResult Index()
        {
            return View(db.Opery.ToList());
        }

        // GET: Opery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaModel opera = db.Opery.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // GET: Opery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opery/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperaID,Nazwa,Rok,Kompozytor,Dlugosc")] OperaModel opera)
        {
            if (ModelState.IsValid)
            {
                db.Opery.Add(opera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opera);
        }

        // GET: Opery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaModel opera = db.Opery.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // POST: Opery/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperaID,Nazwa,Rok,Kompozytor,Dlugosc")] OperaModel opera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }

        // GET: Opery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaModel opera = db.Opery.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }
            return View(opera);
        }

        // POST: Opery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OperaModel opera = db.Opery.Find(id);
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
