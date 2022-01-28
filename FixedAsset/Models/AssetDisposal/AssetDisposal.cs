using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.AssetDisposal
{
    public class AssetDisposal
    {
        public int Id { get; set; }
        public string FACode { get; set; }
        public string FALocationCode { get; set; }
        public string Age { get; set; }
        public string AccumDep { get; set; }
        public string AssetGL { get; set; }
        public string netbookpos { get; set; }
        public Nullable<int> LifeSpan { get; set; }
        public Nullable<decimal> DisposalAmt { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<decimal> OtherCostWriteoff { get; set; }
        public byte[] TranDate { get; set; }
        public string Narration { get; set; }
        public string DRGL { get; set; }
        public string CRGL { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    }
}