using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Setup.FAAncilaryClass
{
    public class FAAncilaryClassModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string ClassCode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string CostCode { get; set; }
        public int? status { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    }
}