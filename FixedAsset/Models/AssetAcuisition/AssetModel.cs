using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.AssetAcuisition
{
    public class AssetModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string CatCode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string ClassCode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string FACode { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string FAName { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<int> DepMethod { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<decimal> Deprate { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<int> LifeSpan { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string LocationCode { get; set; }
        public byte[] PurchaseDate { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<decimal> FACost { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<decimal> ResidualVal { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<decimal> AccumDep { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<int> LifeSpanUsed { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<System.DateTime> DepStartDate { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string FAGLAccount { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string FundingGL { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string AccumDepGL { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string ExpenseGL { get; set; }
        public Nullable<int> Status { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<int> DisposalMethod { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public Nullable<decimal> DisposalAmt { get; set; }
        public string UserID { get; set; }
        public string AuthID { get; set; }
    }
}