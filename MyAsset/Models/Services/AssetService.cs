using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyAsset.Models.ViewModels;

namespace MyAsset.Models.Services
{
    public class AssetService
    {
        private readonly AccountModel _db;

        public AssetService()
        {
            _db = new AccountModel();
        }

        public void Create(AssetViewModel record)
        {
            throw new NotImplementedException();
        }
        public void Update(AssetViewModel record)
        {
            throw new NotImplementedException();
        }
        public void Delete(AssetViewModel record)
        {
            throw new NotImplementedException();
        }
        public AssetViewModel GetSingle(string assetID)
        {
            return  GetAll().Where(d => d.AssetID == assetID).FirstOrDefault();
        }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
        public List<AssetViewModel> GetAll()
        {
            #region List Objects Sample
            //Demo:建立 DateTime 千萬不要用轉的，這樣很浪費效能，尤其你選擇的是 Convert.Toxxx 這是最耗效能的轉法
            //建議直接 new DateTime(2016, 1, 1) 即可
            //List<AssetViewModel> records = new List<AssetViewModel>()
            //{
            //    new AssetViewModel { AssetID = 1, Category ="支出", CreatedDate = new DateTime(2016,1,1), Money = 300 },
            //    new AssetViewModel { AssetID = 2, Category ="支出", CreatedDate = new DateTime(2016,1,2), Money = 1600 },
            //    new AssetViewModel { AssetID = 3, Category ="支出", CreatedDate = new DateTime(2016,1,3), Money = 800 },
            //    new AssetViewModel { AssetID = 3, Category ="支出", CreatedDate = new DateTime(2016,1,4), Money = 10000 }
            //};
            #endregion

            //Projection to  Class
            List<AssetViewModel> records = _db.AccountBook.Select(d =>
              new AssetViewModel()
              {
                  AssetID = d.Id.ToString(),
                  Category = (d.Categoryyy == 0) ? "支出" : "收入",
                  CreatedDate = d.Dateee,
                  Money = d.Amounttt,
                  Remark = d.Remarkkk
              }).ToList();
            return records;
        }

    }
}