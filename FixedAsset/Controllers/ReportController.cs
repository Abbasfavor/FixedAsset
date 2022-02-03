using FixedAsset.Repository.Report;
using FixedAsset.Repository.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAsset.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private IRptFARegisterRepo _entity;
        private readonly IBranch _IBranch;
        public ReportController()
        {
            _entity = new RptFARegisterRepo(new Models.FixedAssetEntities());
            _IBranch = new Branch(new Models.FixedAssetEntities());
        }

        public ReportController(IRptFARegisterRepo entity, IBranch IBranch)
        {
            _entity = entity;
            _IBranch = IBranch;
        }

        // GET: Report
        [HttpGet]
        public ActionResult GetRegister()
        {
            var BranchCode = _IBranch.GetBranch();
            ViewBag.BranchCode = BranchCode;
            return View();  
        }

        public ActionResult GetRegisterReport(string Branchcode, string FAClass)
        {
            var model = _entity.GetFARegister(Branchcode, FAClass);
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}

