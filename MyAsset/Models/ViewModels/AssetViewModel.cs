using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAsset.Models.ViewModels
{
    public class AssetViewModel
    {
        [Key]
        [Display(Name = "AssetID")]
        public int AssetID { get; set; }
        [Display(Name = "類別")]
        public string Category { get; set; }
        [Display(Name = "日期")]
        public DateTime CreatedDate  { get; set; }
        [Display(Name = "金額")]
        public int Money { get; set; }
    }
}