using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Apteczka.Data_Access;
using Apteczka.Models;
using PagedList;

namespace Apteczka.Controllers
{
    public class LekController : Controller
    {
        private ApteczkaContext db = new ApteczkaContext();

        // GET: Lek
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "Nazwa_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Data" ? "Data_desc" : "Data";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var lekiDbQuery = from leki in db.LekiDB.Include(l => l.Apteczka) select leki;

            if (!String.IsNullOrEmpty(searchString))
            {
                lekiDbQuery = lekiDbQuery.Where(lek => lek.Nazwa.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Nazwa_desc":
                    lekiDbQuery = lekiDbQuery.OrderByDescending(lek => lek.Nazwa);
                    break;
                case "Data":
                    lekiDbQuery = lekiDbQuery.OrderBy(lek => lek.TerminWaznosci);
                    break;
                case "Data_desc":
                    lekiDbQuery = lekiDbQuery.OrderByDescending(lek => lek.TerminWaznosci);
                    break;
                default:
                    lekiDbQuery = lekiDbQuery.OrderBy(lek => lek.Nazwa);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(lekiDbQuery.ToPagedList(pageNumber, pageSize));
        }

        // GET: Lek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LekModel lekModel = db.LekiDB.Find(id);
            if (lekModel == null)
            {
                return HttpNotFound();
            }
            return View(lekModel);
        }

        // GET: Lek/Create
        public ActionResult Create()
        {
            ViewBag.ApteczkaID = new SelectList(db.ApteczkiDB, "ID", "Nazwa");
            return View();
        }

        // POST: Lek/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApteczkaID,Nazwa,Kategoria,Forma,Producent,Ilosc,TerminWaznosci")] LekModel lekModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.LekiDB.Add(lekModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException/* dEx */)
            {
                ModelState.AddModelError("", "Nie można zapisać danych. Spróbuj ponownie, jeśli problem będzie występował skontaktuj się z administratorem.");
            }

            ViewBag.ApteczkaID = new SelectList(db.ApteczkiDB, "ID", "Nazwa", lekModel.ApteczkaID);
            return View(lekModel);
        }

        // GET: Lek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LekModel lekModel = db.LekiDB.Find(id);
            if (lekModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApteczkaID = new SelectList(db.ApteczkiDB, "ID", "Nazwa", lekModel.ApteczkaID);
            return View(lekModel);
        }

        // POST: Lek/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LekModel lekToUpdate = db.LekiDB.Find(id);
            if (TryUpdateModel(lekToUpdate, "",
                new string[] { "ApteczkaID", "Nazwa", "Kategoria", "Forma", "Producent", "Ilosc", "TerminWaznosci" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException/* dEx */)
                {
                    ModelState.AddModelError("", "Nie można zapisać danych. Spróbuj ponownie, jeśli problem będzie występował skontaktuj się z administratorem.");
                }
            }
            ViewBag.ApteczkaID = new SelectList(db.ApteczkiDB, "ID", "Nazwa", lekToUpdate.ApteczkaID);
            return View(lekToUpdate);
        }

        // GET: Lek/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Usuwanie nie powiodło się. Spróbuj ponownie, jeśli problem będzie występował skontaktuj się z administratorem.";
            }
            LekModel lekModel = db.LekiDB.Find(id);
            if (lekModel == null)
            {
                return HttpNotFound();
            }
            return View(lekModel);
        }

        // POST: Lek/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                LekModel lekModel = db.LekiDB.Find(id);
                db.LekiDB.Remove(lekModel);
                db.SaveChanges();
            }
            catch (DataException/* dEx */)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }            
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
