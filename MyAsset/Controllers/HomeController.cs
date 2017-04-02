using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyAsset.Models.Services;
using MvcPaging;  //Web.Config 已經有加上了<add namespace="MvcPaging" />，不知為何還要using? 
using MyAsset.Repositories;
using MyAsset.Models.ViewModels;
using MyAsset.Enum;

namespace MyAsset.Controllers
{
    public class HomeController : Controller
    {
        private readonly AssetService _assetSvc;
        private const int DefaultPageSize = 10;  //每頁顯示筆數


        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _assetSvc = new AssetService(unitOfWork);

        }

        // GET: Home
        public ActionResult Index(int? page = 1)
        {
            ViewBag.Title = "記帳本首頁";
            return View();
        }
        [HttpPost]
        public ActionResult Index(AssetViewModel data)
        {
            if (ModelState.IsValid)
            {
                _assetSvc.Add(data);

                try
                {
                    _assetSvc.Save();
                }
                catch
                {
                    //to do something, log or rediret to view/page


                }

                return View();
            }
            return View(data);

        }


        [ChildActionOnly]
        public ActionResult AssetList(int? page)
        {
            var assetRecords = _assetSvc.Lookup();
            //使用MVCPaging套件
            //http://demo.taiga.nl/mvcpaging/
            //另一套分頁套件:PagedList，和MVCPaging用法類似
            //GitHub:https://github.com/TroyGoode/PagedList

            // 計算出目前要顯示第幾頁的資料 ( 因為 page 為 Nullable<int> 型別 )
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            // 透過 ToPagedList 這個 Extension Method 將原本的資料轉成 IPagedList<T>
            return PartialView(assetRecords.ToPagedList(currentPageIndex, DefaultPageSize));  //return PartialView與View的差別：Partial View不會參考_ViewStart.cshtml中指定的預設值
        }
    }
}