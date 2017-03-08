using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyAsset.Models.ViewModels;

namespace MyAsset.Models.Repository
{
    public class AssetRepository
    {
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
        public AssetViewModel GetByID(int assetID)
        {
            return  GetAll().Where(d => d.AssetID == assetID).FirstOrDefault();
        }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
        public List<AssetViewModel> GetAll()
        {
            List<AssetViewModel> records = new List<AssetViewModel>()
            {
                new AssetViewModel { AssetID = 1, Category ="支出", CreatedDate = Convert.ToDateTime("2016-01-01"), Money = 300 },
                new AssetViewModel { AssetID = 2, Category ="支出", CreatedDate = Convert.ToDateTime("2016-01-02"), Money = 1600 },
                new AssetViewModel { AssetID = 3, Category ="支出", CreatedDate = Convert.ToDateTime("2016-01-03"), Money = 800 },
                new AssetViewModel { AssetID = 3, Category ="支出", CreatedDate = Convert.ToDateTime("2016-01-04"), Money = 10000 }
            };
            return records;
        }

    }
}