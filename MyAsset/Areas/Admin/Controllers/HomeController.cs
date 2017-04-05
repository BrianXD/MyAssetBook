using MyAsset.Models.Services;
using MyAsset.Models.ViewModels;
using MyAsset.Repositories;
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
        private readonly AssetService _assetSvc;
        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _assetSvc = new AssetService(unitOfWork);

        }
        // GET: Admin/Home
        [Authorize(Roles = "skilltree")] //指定skill群組才可以進
        public ActionResult Edit(string id)
        {
            AssetViewModel data = null;
            if (!string.IsNullOrEmpty(id))
            {
                data = _assetSvc.GetSingle(new Guid(id));
            }
            return View(data);
        }
        [Authorize(Roles = "skilltree")] //指定skill群組才可以進
        [HttpPost]       
        public ActionResult Edit(AssetViewModel data,string id)
        {
            if (ModelState.IsValid)
            {
                _assetSvc.Edit(data, new Guid(id));
                try
                {
                    _assetSvc.Save();
                }
                catch
                {
                    //to do something, log or redirect to view/page
                }
            }
            return RedirectToAction("index", "home", new { area = "" } );
        }

        [Authorize(Roles = "AAA")] //only for AAA Role
        public ActionResult Add()
        {
            return View();
        }
    }
}