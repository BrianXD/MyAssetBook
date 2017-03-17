using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyAsset.Models.ViewModels;
using MyAsset.Repositories;

namespace MyAsset.Models.Services
{
    public class AssetService
    {
        private readonly IRepository<AccountBook> _assetRep;
        private readonly IUnitOfWork _unitOfWork;
        public AssetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _assetRep = new Repository<AccountBook>(unitOfWork);
        }    
       
        public IQueryable<AssetViewModel> Lookup()
        {

            var source = _assetRep.LookupAll();
            var result = source.Select(d =>
              new AssetViewModel()
              {
                  //AssetID = d.Id.ToString(),  //Guid 無法轉 int
                  Category = (d.Categoryyy == 0) ? "支出" : "收入",
                  CreatedDate = d.Dateee,
                  Money = d.Amounttt,
                  Remark = d.Remarkkk
              });
            return result.OrderByDescending(d => d.CreatedDate).ThenByDescending(d => d.Category);
        }

    }
}