using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloDotNET.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
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
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }




        public ActionResult Index()
        {
            return View();
        }

    }
}
