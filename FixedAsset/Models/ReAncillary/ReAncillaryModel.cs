using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.ReAncillary
{
    public class ReAncillaryModel
    {
        public int Id { get; set; }
        public string FACode { get; set; }
        public string CostCode { get; set; }
        public Nullable<decimal> Amount { get; set; }


        public Nullable<System.DateTime> TranDate { get; set; }
   


        public string Narration { get; set; }
        public Nullable<int> ExpMethod { get; set; }
        public string DRAccount { get; set; }
        public string CRAccount { get; set; }
        public Nullable<decimal> MonthlyRunRate { get; set; }
        public Nullable<System.DateTime> NextAmortDate { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    
}
}