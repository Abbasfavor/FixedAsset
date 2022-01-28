using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Setup.Role
{
    public class RoleModel
    {
        public int role_id { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string role_name { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string roledesc { get; set; }
        public int? access_days { get; set; }
        public DateTime? createdate { get; set; }

        public int? isoperation { get; set; }
        public int? reqLimit { get; set; }
        public int? status { get; set; }
        public string authid { get; set; }
        public string userid { get; set; }
        public int? canauth { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public int? role_level { get; set; }
        public bool? Commitee { get; set; }
    }
}