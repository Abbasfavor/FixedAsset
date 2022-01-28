using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Setup.FAClass
{
    public class FAClassModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string CatCode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string ClassCode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public int? DepMethod { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public decimal? DepRate { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public int? LifeSpan { get; set; }
        public int? status { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    }
}