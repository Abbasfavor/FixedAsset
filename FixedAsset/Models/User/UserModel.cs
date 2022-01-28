using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.User
{
    public class UserModel
    {
        public int? id { get; set; }
        public int? Role_id { get; set; }
        public int? flag { get; set; }
        public int? remotelogin { get; set; }
        public int? statement { get; set; }
        public int? excemptlock { get; set; }
        public int? offlinealert { get; set; }
        public int? enforce_pwd { get; set; }
        public int? emailalert { get; set; }
        public int? smsalert { get; set; }
        public int? Status { get; set; }
        public int? lockcount { get; set; }
        public int? sessionid { get; set; }
        public int? ReportLevel { get; set; }
        public int? Authoriser { get; set; }
        public string Userid { get; set; }
        public string userpassword { get; set; }
        public string fullname { get; set; }
        [Display(Name = "Department")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Department required")]
        public string deptcode { get; set; }
        public string ipaddress { get; set; }
        public string loginstatus { get; set; }
        [Display(Name = "Branch")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Branch required")]
        public string branchcode { get; set; }
        public string Staff_status { get; set; }
        public string PostGL_Acctno { get; set; }
        public DateTime? passchange_date { get; set; }
        public DateTime? Next_Passchange_date { get; set; }
        public DateTime? Create_date { get; set; }
        public long? SScode { get; set; }
        public string Computername { get; set; }
        public string machaddress { get; set; }
        public string AuthUserid { get; set; }
        public string PostUserId { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        public string email { get; set; }
        [Display(Name = "Phone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone required")]
        public string phoneno { get; set; }
        public string authid { get; set; }
        public string authorisedby { get; set; }
        public decimal? targetamt { get; set; }
        public int? logincount { get; set; }
        public int? multilogin { get; set; }
        public int? SBU { get; set; }
        public int? reportflag { get; set; }
        public string ConfirmPassword { get; set; }
        public string PasswordResetCode { get; set; }
        [Display(Name = "First name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        public string firstname { get; set; }
        [Display(Name = "Last name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string lastname { get; set; }
  
        public string othername { get; set; }
        public bool? IsEmailVerified { get; set; }
        public Guid? ActivationCode { get; set; }
    }
}