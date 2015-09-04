using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers {

    public class HomeController : Controller {

        private IRepository _repo;

        public HomeController(IRepository repo) {
            _repo = repo;
        }

        public ActionResult Index() {
            return View("List", _repo.Query<ApplicationUser>().OrderBy(a => a.UserName).ToList());
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}