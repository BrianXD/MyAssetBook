using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAsset.Filters;
using MyAsset.Enum;
namespace MyAsset.Models.ViewModels
{
    public class AssetViewModel
    {

      

        [Display(Name = "AssetGUID")]
     
        public Guid AssetGUID { get; set; }

        [Display(Name = "ID")]     
        public int AssetID { get; set; }


        [Display(Name = "類別")]
        public string Category { get; set; }

        [Display(Name = "類別")]
        [Required]
        public MyEnumCategory? Categories { get; set; }


        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Required]
        //MVC內建remote驗證，1.javascript關掉就無法work 2.如果有使用area且驗證controller放在root下會找不到
        //[Remote("ValidDate", "Home", ErrorMessage = "日期不可大於今日")]
        //Demo提供的客製remote可以解決以上問題
        [RemoteDoublePlus("ValidDate", "Valid", "", ErrorMessage = "日期不可大於今日")]

        public DateTime CreatedDate  { get; set; }

        [Display(Name = "金額")] 
        [DisplayFormat(DataFormatString = "{0:#,###}")]       
        [Required]
        [Range(1, int.MaxValue)]
        [UIHint("IntSPINNER")]
        public int Money { get; set; }

        [Display(Name = "備註")]        
        [Required]
        [StringLength(100, ErrorMessage="{0}的最大長度不得超過{1}")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

     
    }

 
}