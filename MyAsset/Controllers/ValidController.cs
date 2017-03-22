using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAsset.Controllers
{
    public class ValidController : Controller
    {
        public ActionResult ValidDate(DateTime? createdDate)
        {
            bool isValidate = (createdDate <= DateTime.Now);
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }

    }
}