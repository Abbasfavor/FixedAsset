using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.AssetRevaluation
{
    public class AssetRevaluation
    {
        public int Id { get; set; }
        public string FACode { get; set; }
        public string FALocationCode { get; set; }
        public Nullable<decimal> PrevValue { get; set; }
        public string AccumDep { get; set; }
        public Nullable<int> LifeSpan { get; set; }
        public string netbookpos { get; set; }
        public string Tenor { get; set; }
        public string Age { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<decimal> CurrentValue { get; set; }
        public byte[] RevDate { get; set; }
        public Nullable<int> status { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    }
}