using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloDotNET.Controllers
{
    public class AfterLoginController : Controller
    {
        private CrmAppleEntities db = new CrmAppleEntities();

        //
        // GET: /AfterLogin/

        public ActionResult Index()
        {
            ViewBag.Nama = "Realtionship Management";
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Event()
        {
            return View();
        }

        public ActionResult About_Us()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Admin()
        {

            return View();
        }

        public ActionResult LoginCustomer()
        {
            return View();
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }

        public ActionResult HomeAdmin()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }
    }
}