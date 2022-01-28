using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Setup.Branch
{
    public class BrancModel
    {
        [Required(ErrorMessage = "field is required.")]
        public string BranchCode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string Address { get; set; }
        public string address2 { get; set; }
        public string Address3 { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string phone { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string email { get; set; }
        public string fax { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string Country { get; set; }
        public Nullable<int> status { get; set; }
        public string cashaccount { get; set; }
        public string suspenseDR { get; set; }
        public string suspenseCR { get; set; }
        public string InterBranchGL { get; set; }
        public Nullable<int> BranchType { get; set; }
        public string MBranchCode { get; set; }
        public string SBranchCode { get; set; }
        public string Userid { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string region { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
        public string authid { get; set; }
        public Nullable<int> subbranch { get; set; }
    }
}