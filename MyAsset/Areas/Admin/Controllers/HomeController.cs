using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAsset.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [Authorize(Roles = "skilltree")] //指定skill群組才可以進
        public ActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "AAA")] //only for AAA Role
        public ActionResult Add()
        {
            return View();
        }
    }
}