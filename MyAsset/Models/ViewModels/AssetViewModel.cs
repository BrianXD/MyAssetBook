using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAsset.Models.ViewModels
{
    public class AssetViewModel
    {

      

        [Display(Name = "AssetGUID")]
     
        public Guid AssetGUID { get; set; }

        [Display(Name = "ID")]     
        public int AssetID { get; set; }

    
     
        public string Category { get; set; }

        [Display(Name = "類別")]             
        [Range(0,1, ErrorMessage = "請選擇一個分類")]
        public MyEnumCategory Categories { get; set; }


        [Display(Name = "日期")]
        [Required]
        [Remote("ValidDate", "Home", ErrorMessage = "日期不可大於今日")]     
        public DateTime? CreatedDate  { get; set; }

        [Display(Name = "金額")]        
        [Required]
        [Range(1, int.MaxValue)]
        public int? Money { get; set; }

        [Display(Name = "備註")]        
        [Required]
        [StringLength(100, ErrorMessage="{0}的最大長度不得超過{1}")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

     
    }

    public enum MyEnumCategory
    {
        選擇一個類別 = 2,
        支出 = 0,
        收入 = 1,
      
    }
}