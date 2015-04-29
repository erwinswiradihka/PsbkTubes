using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloDotNET.Controllers
{
    public class ServiController : Controller
    {
        private CrmAppleEntities db = new CrmAppleEntities();

        //
        // GET: /Servi/

        public ActionResult Index()
        {
            return View(db.Servis.ToList());
        }

        //
        // GET: /Servi/Details/5

        public ActionResult Details(int id = 0)
        {
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        //
        // GET: /Servi/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Servi/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Servi servi)
        {
            if (ModelState.IsValid)
            {
                db.Servis.Add(servi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servi);
        }

        //
        // GET: /Servi/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        //
        // POST: /Servi/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Servi servi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servi);
        }

        //
        // GET: /Servi/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        //
        // POST: /Servi/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servi servi = db.Servis.Find(id);
            db.Servis.Remove(servi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}