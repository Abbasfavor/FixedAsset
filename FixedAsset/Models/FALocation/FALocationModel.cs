using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.FALocation
{
    public class FALocationModel
    {
        public int Id { get; set; }
        public string FACode { get; set; }
        public string FALocationCode { get; set; }
        public byte[] DateAllocated { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> ReceiptStatus { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
        public string ReceiptBy { get; set; }
        public string AssetGL { get; set; }
        public string AccumDepGL { get; set; }
        public string DepExpenseGL { get; set; }
    }
}