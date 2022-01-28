using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Setup.FACategory
{
    public class Asset_Categorym
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string CatCode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string CatDesc { get; set; }
        public int? status { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    }
}