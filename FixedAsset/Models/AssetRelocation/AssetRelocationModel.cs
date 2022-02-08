using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.AssetRelocation
{
    public class AssetRelocationModel
    {

        //public int Id { get; set; }
        //public string FACode { get; set; }
        //public string FALocationCode { get; set; }
        //public string branch { get; set; }
        //public string officerEmail { get; set; }
        //public byte[] DateAllocated { get; set; }
        //public Nullable<int> Status { get; set; }
        //public Nullable<int> ReceiptStatus { get; set; }
        //public string UserID { get; set; }
        //public string AuthID { get; set; }
        //public string ReceiptBy { get; set; }
        //public string AssetGL { get; set; }
        //public string CRAccount { get; set; }
        //public string DRAccount { get; set; }
        //public string AccumDepGL { get; set; }
        //public string DepExpenseGL { get; set; }

        public int Id { get; set; }
        public string FACode { get; set; }
        public string FALocationCode { get; set; }
        //public string Branch { get; set; }

        public string BranchCode { get; set; }

        public string BranchName { get; set; }



        public string OffEmail { get; set; }

        public Nullable<DateTime> DateAllocated { get; set; }

        public Nullable<int> Status { get; set; }
        public Nullable<int> ReceiptStatus { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
        public string ReceiptBy { get; set; }
        public string AssetGL { get; set; }
        public string CRAccount { get; set; }
        public string DRAccount { get; set; }
        public string AccumDepGL { get; set; }
        public string DepExpenseGL { get; set; }
    }
}