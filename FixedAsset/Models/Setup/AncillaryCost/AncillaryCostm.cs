using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Setup.AncillaryCost
{
    public class AncillaryCostm
    {
        public int Id { get; set; }
        public string CostCode { get; set; }
        public string CostDesc { get; set; }
        public int? Capitalized { get; set; }
        public int? status { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    }
}