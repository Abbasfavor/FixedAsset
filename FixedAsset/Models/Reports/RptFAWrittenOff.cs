using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Reports
{
    public class RptFAWrittenOff
    {
        public long? Id { get; set; }
        public string FACode { get; set; }
        public string FAName { get; set; }
        public string ClassName { get; set; }
        public string DepMethod { get; set; }
        public decimal? Deprate { get; set; }
        public int? LifeSpan { get; set; }
        public string BranchName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal? FACost { get; set; }
        public decimal? ResidualVal { get; set; }
        public decimal? AccumDep { get; set; }
        public int? LifeSpanUsed { get; set; }
        public DateTime? DepStartDate { get; set; }
        public DateTime? Disposed_Date { get; set; }
        public decimal? Disposed_Amount { get; set; }
        public decimal? Disposable_Value { get; set; }
        public decimal? Gain_Loss { get; set; }
        public string Narration { get; set; }
        public string DisposedGL { get; set; }
        public string FAGLAccount { get; set; }
        public string FundingGL { get; set; }
        public string AccumDepGL { get; set; }
        public string ExpenseGL { get; set; }
    }
}