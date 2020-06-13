using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Apteczka.Data_Access;
using Apteczka.Models;
using PagedList;

namespace Apteczka.Controllers
{
    public class ApteczkaController : Controller
    {
        private ApteczkaContext db = new ApteczkaContext();

        // GET: Apteczka
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

            var apteczkiDbQuery = from apt in db.ApteczkiDB select apt;

            if (!String.IsNullOrEmpty(searchString))
            {
                apteczkiDbQuery = apteczkiDbQuery.Where(apt => apt.Nazwa.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Nazwa_desc":
                    apteczkiDbQuery = apteczkiDbQuery.OrderByDescending(apt => apt.Nazwa);
                    break;
                case "Data":
                    apteczkiDbQuery = apteczkiDbQuery.OrderBy(apt => apt.DataUtworzenia);
                    break;
                case "Data_desc":
                    apteczkiDbQuery = apteczkiDbQuery.OrderByDescending(apt => apt.DataUtworzenia);
                    break;
                default:
                    apteczkiDbQuery = apteczkiDbQuery.OrderBy(apt => apt.Nazwa);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(apteczkiDbQuery.ToPagedList(pageNumber, pageSize));
        }

        // GET: Apteczka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApteczkaModel apteczkaModel = db.ApteczkiDB.Find(id);
            if (apteczkaModel == null)
            {
                return HttpNotFound();
            }
            return View(apteczkaModel);
        }

        // GET: Apteczka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apteczka/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwa,DataUtworzenia")] ApteczkaModel apteczkaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ApteczkiDB.Add(apteczkaModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException/* dEx */)
            {
                ModelState.AddModelError("", "Nie można zapisać danych. Spróbuj ponownie, jeśli problem będzie występował skontaktuj się z administratorem.");
            }
            return View(apteczkaModel);
        }

        // GET: Apteczka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApteczkaModel apteczkaModel = db.ApteczkiDB.Find(id);
            if (apteczkaModel == null)
            {
                return HttpNotFound();
            }
            return View(apteczkaModel);
        }

        // POST: Apteczka/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApteczkaModel apteczkaToUpdate = db.ApteczkiDB.Find(id);
            if (TryUpdateModel(apteczkaToUpdate, "",
                new string[] { "Nazwa", "DataUtworzenia" }))
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
            return View(apteczkaToUpdate);
        }

        // GET: Apteczka/Delete/5
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
            ApteczkaModel apteczkaModel = db.ApteczkiDB.Find(id);
            if (apteczkaModel == null)
            {
                return HttpNotFound();
            }
            return View(apteczkaModel);
        }

        // POST: Apteczka/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                ApteczkaModel apteczkaModel = db.ApteczkiDB.Find(id);
                db.ApteczkiDB.Remove(apteczkaModel);
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
