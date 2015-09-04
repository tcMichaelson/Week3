using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ManageUsersController : Controller {
        private CacheRepository _repo;

        public ManageUsersController(CacheRepository repo) {
            _repo = repo;
        }

        // GET: ManageUsers
        public ActionResult Index()
        {
            //_repo.Query<Identity.Models.ApplicationUser>().ToList()
            return View(_repo.Query<ApplicationUser>().ToList());
        }
    }
}