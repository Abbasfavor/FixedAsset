using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.AssetAcuisition
{
    public class AncillaryCostType
    {
        public int? Id { get; set; }
        public string CostCode { get; set; }
        public string ClassCode { get; set; }
        public decimal? CostAmount { get; set; }
        public string CapitalizedType { get; set; }
        public string CreditGL { get; set; }
        public string DebittGL { get; set; }

      
    }
}