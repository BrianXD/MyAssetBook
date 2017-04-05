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
        public AssetViewModel GetSingle(Guid guid)
        {
            var assetItem = _assetRep.GetSingle(d => d.Id == guid);
            var assetViewModel =
                new AssetViewModel()
                {
                    AssetGUID = assetItem.Id,
                    Categories = (Enum.MyEnumCategory) assetItem.Categoryyy,
                    CreatedDate = assetItem.Dateee,
                    Money = assetItem.Amounttt,
                    Remark = assetItem.Remarkkk
                  };
            return assetViewModel;
        }

        public IQueryable<AssetViewModel> Lookup()
        {

            var source = _assetRep.LookupAll();
            var result = source.Select(d =>
              new AssetViewModel()
              {
                  //AssetID = d.Id.ToString(),  //Guid 無法轉 int                  
                  AssetGUID = d.Id,                  
                  Category = (d.Categoryyy == 0) ? "支出" : "收入",
                  CreatedDate = d.Dateee,
                  Money = d.Amounttt,
                  Remark = d.Remarkkk
              });
            return result.OrderByDescending(d => d.CreatedDate).ThenByDescending(d => d.Category);
        }
        public void Add(AssetViewModel data)
        {
            var result = new AccountBook()
            {
               
                Amounttt = data.Money,
                Categoryyy = (int)data.Categories,
                Dateee = data.CreatedDate,
                Remarkkk = data.Remark
               
            };
            Add(result);
        }
        public void Add(AccountBook data)
        {
            data.Id = Guid.NewGuid();
            _assetRep.Create(data);
        }
        public void Edit(AssetViewModel data, Guid id)
        {
            AccountBook oldData = _assetRep.GetSingle(d => d.Id == id);           
            oldData.Categoryyy = (int)data.Categories;
            oldData.Amounttt = data.Money;
            oldData.Dateee = data.CreatedDate;
            oldData.Remarkkk = data.Remark;
        }
        public void Save()
        {
            _unitOfWork.Save();
        }

    }
}