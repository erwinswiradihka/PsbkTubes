using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloDotNET.Controllers
{
    public class CustomerController : Controller
    {
        private CrmAppleEntities db = new CrmAppleEntities();

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View(db.Logins.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login u)
        {

            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {

                using (CrmAppleEntities dc = new CrmAppleEntities())
                {
                    var v = dc.Logins.Where(a => a.Username.Equals(u.Username) && a.Kunci.Equals(u.Kunci)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.Id_User.ToString();
                        Session["LogedUserFullname"] = v.Username.ToString();
                        return RedirectToAction("Index","AfterLogin");
                    }
                }
            }
            return View(u);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id = 0)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        public ActionResult Index1()
        {

            return View();

        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterCustomer(Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Login", "Customer");
            }

            return View(login);
        }



        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
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