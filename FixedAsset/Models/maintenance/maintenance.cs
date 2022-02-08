using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.maintenance
{
    public class maintenance
    {

        public int Id { get; set; }
        public string OperaType { get; set; }
        public string FACode { get; set; }
        public string Description { get; set; }
        public decimal? CapitalAmount { get; set; }

        public DateTime MaintDate { get; set; }
        public DateTime NextMaintDate { get; set; }

        public decimal Amount { get; set; }
        public string DRAccount { get; set; }
        public string CRAccount { get; set; }
        public string CapitaliseTpe { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
        //public int Id { get; set; }
        //public string FACode { get; set; }
        //public string Narration { get; set; }
        //public decimal? Tranamount { get; set; }
        //public decimal? CapitalAmount { get; set; }
        //public byte[] TranDate { get; set; }
        //public int? expMethod { get; set; }
        //public string DRGL { get; set; }
        //public string CRGL { get; set; }
        //public int? MaintType { get; set; }
        //public int? Capitalisetype { get; set; }
        //public string UserID { get; set; }
        //public string AuthID { get; set; }
    }
}