using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyAsset.Models.Repository;
namespace MyAsset.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MyTitle = ViewBag.Title = "記帳本首頁";
            return View();
        }
        [ChildActionOnly]
        public ActionResult AssetList()
        {
            AssetRepository assetRepos = new AssetRepository();
            var assetRecords = assetRepos.GetAll();
            return PartialView(assetRecords);  //return PartialView與View的差別：Partial View不會參考_ViewStart.cshtml中指定的預設值
        }
    }
}