using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloDotNET.Controllers
{
    public class ProdukController : Controller
    {
        private CrmAppleEntities db = new CrmAppleEntities();

        //
        // GET: /Produk/

        public ActionResult Index()
        {
            return View(db.Produks.ToList());
        }

        //
        // GET: /Produk/Details/5

        public ActionResult Details(int id = 0)
        {
            Produk produk = db.Produks.Find(id);
            if (produk == null)
            {
                return HttpNotFound();
            }
            return View(produk);
        }

        //
        // GET: /Produk/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produk/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produk produk)
        {
            if (ModelState.IsValid)
            {
                db.Produks.Add(produk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produk);
        }

        //
        // GET: /Produk/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Produk produk = db.Produks.Find(id);
            if (produk == null)
            {
                return HttpNotFound();
            }
            return View(produk);
        }

        //
        // POST: /Produk/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produk produk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produk);
        }

        //
        // GET: /Produk/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Produk produk = db.Produks.Find(id);
            if (produk == null)
            {
                return HttpNotFound();
            }
            return View(produk);
        }

        //
        // POST: /Produk/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produk produk = db.Produks.Find(id);
            db.Produks.Remove(produk);
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