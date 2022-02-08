using FixedAsset.Repository.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FixedAsset.Models.maintenance;

namespace FixedAsset.Controllers
{
    [Authorize]
    public class AssetMaintenanceController : Controller
    {
        private IMaintenance _db;

        public AssetMaintenanceController()
        {
            _db = new Maintenance(new Models.FixedAssetEntities());
        }

        public AssetMaintenanceController(IMaintenance entity)
        {
            _db = entity;
        }


        // GET: AssetMaintenance
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult MaintainanceList()
        {
            var model = _db.GetMaintances();
            return View(model);
        }




        [HttpGet]
        public ActionResult Create()
        {
            var Amortise = _db.Get_AmortiseType();
            ViewBag.Amortise = Amortise;
            return View();
        }
        [HttpPost]
        public ActionResult Create(maintenance model)
        {

            var Amortise = _db.Get_AmortiseType();
            ViewBag.Amortise = Amortise;
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _db.CraeteMaintances(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                }
                else
                {
                    Status = false;
                    Message = data.retmsg;
                }
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View();
        }








        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var Amortise = _db.Get_AmortiseType();
            ViewBag.Amortise = Amortise;
            var result = _db.GetMaintainId(Id);
            return View(result);
        }






        [HttpPost]
        public ActionResult Edit(maintenance model)
        {
            var Amortise = _db.Get_AmortiseType();
            ViewBag.Amortise = Amortise;
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _db.UpdateMaintances(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                }
                else
                {
                    Status = false;
                    Message = data.retmsg;
                }
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View();
        }


    }

}