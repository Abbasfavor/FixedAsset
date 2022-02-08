using FixedAsset.Models.ReAncillary;
using FixedAsset.Repository.ReAncillary;
using FixedAsset.Repository.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAsset.Controllers
{
    [Authorize]
    public class ReAncillaryController : Controller
    {

        private readonly IReAncillary _db;
        private readonly IAncillaryCost _entity;


        public ReAncillaryController()
        {
            _db = new ReAncillary(new Models.FixedAssetEntities());
            _entity = new AncillaryCost(new Models.FixedAssetEntities());

        }



        public ReAncillaryController(IReAncillary db, IAncillaryCost entity)


        {

            _db = db;
            _entity = entity;
        }

        public ActionResult ACillaryCostList()
        {
            var model = _db.GetACillaryCost();
            return View(model);
        }




        [HttpGet]
        public ActionResult Create()
        {
            var AnliarryCost = _entity.GetAncillaryCost();
            ViewBag.AnliarryCost = AnliarryCost;
            return View();
        }
        [HttpPost]
        public ActionResult Create(ReAncillaryModel model)
        {
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _db.CraeteAnciCost(model);
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
            var result = _db.GetAncillaryId(Id);
            return View(result);
        }






        [HttpPost]
        public ActionResult Edit(ReAncillaryModel model)
        {
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _db.UpdateAnciCost(model);
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






        public ActionResult Delete(int Id)
        {
            var model = new ReAncillaryModel();
            model.UserID = "";
            model.AuthID = "";
            model.Id = Id;

            var result = _db.DeleteAnciCost(model);
            if (result.retVal == 0)
            {
                ViewData["Message"] = result.retmsg;
                return RedirectToAction("ACillaryCostList", "ReAncillary");
            }
            else
            {
                ViewData["Message"] = result.retmsg;
            }
            return View();
        }



    }
}