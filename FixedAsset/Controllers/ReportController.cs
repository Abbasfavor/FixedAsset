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
        private readonly IReportRepo _entity;
        private readonly IBranch _IBranch;
        public ReportController()
        {
            _entity = new ReportRepo(new Models.FixedAssetEntities());
            _IBranch = new Branch(new Models.FixedAssetEntities());
        }

        public ReportController(IReportRepo entity, IBranch IBranch)
        {
            _entity = entity;
            _IBranch = IBranch;
        }


        [HttpGet]
        public ActionResult GetFARegister()
        {
            var BranchCode = _IBranch.GetBranch();
            ViewBag.BranchCode = BranchCode;
 return View();  
        }

        public ActionResult GetFADisposed()
        {
            var BranchCode = _IBranch.GetBranch();
            ViewBag.BranchCode = BranchCode;
            return View();
        }

        public ActionResult GetFAWrittenOff()
        {
            var BranchCode = _IBranch.GetBranch();
            ViewBag.BranchCode = BranchCode;
            return View();
        }
        public ActionResult GetFAMaint_Repairs()
        {
            var BranchCode = _IBranch.GetBranch();
            ViewBag.BranchCode = BranchCode;
            return View();
        }
        public ActionResult GetFAMaintRepairByCode()
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

        public ActionResult GetFADisposeReport(string Branchcode, string FAClass, DateTime startdate, DateTime eddate)
        {
            var model = _entity.GetFADisposed(Branchcode, FAClass, startdate, eddate);
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        public ActionResult GetFAWrittenOffReport(string Branchcode, string FAClass, DateTime startdate, DateTime eddate)
        {
            var model = _entity.GetFAWrittenOff(Branchcode, FAClass, startdate, eddate);
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        public ActionResult GetFAMaint_RepairsReport()
        {
            var model = _entity.GetFAMaint_Repairs();
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult GetFAMaintRepairByCodeReport(string FaCode, int retportType)
        {
            var model = _entity.GetFAMaintRepairByCode(FaCode, retportType);
            if (model != null)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}

