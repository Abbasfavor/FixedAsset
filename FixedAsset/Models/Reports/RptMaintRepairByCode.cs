using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Reports
{
    public class RptMaintRepairByCode
    {
        public long? Id { get; set; }
        public string FACode { get; set; }
        public string FAName { get; set; }
        public int? LifeSpanUsed { get; set; }
        public string ExpMthod { get; set; }

        public string Narration { get; set; }
        public int? MaintType { get; set; }
        public int? LifeSpan { get; set; }

        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? TranDate { get; set; }

        public decimal? Tranamount { get; set; }



    }
}