using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixedAsset.Models.Setup.Department
{
    public class DepartModel
    {
        [Required(ErrorMessage = "field is required.")]
        public string Deptid { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "field is required.")]
        public string DeptShortname { get; set; }
        public Nullable<int> status { get; set; }
        public string userid { get; set; }
        public string authid { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
    }
}