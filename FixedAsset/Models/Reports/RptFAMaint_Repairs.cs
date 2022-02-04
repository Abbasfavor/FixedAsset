using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Reports
{
    public class RptFAMaint_Repairs
    {
        public long? Id { get; set; }
        public string FaCode { get; set; }
        public string FAName { get; set; }
        public int? LifeSpan { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? LifeSpanUsed { get; set; }
        public int? Maintenance_Count { get; set; }
        public int? Maint_Amount { get; set; }
        public int? Repair_Amount { get; set; }
        public int? Repairs_Count { get; set; }
        public DateTime? Last_Maint_Date { get; set; }
        public DateTime? Last_Repair_Date { get; set; }

    }
}