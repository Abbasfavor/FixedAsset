using FixedAsset.Models.AssetRelocation;
using FixedAsset.Repository.AssetRelocation;
using FixedAsset.Repository.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAsset.Controllers
{
    [Authorize]
    public class AssetRelocationController : Controller
    {

        private IRelocation _db;
        private IBranch _IBranch;


        public AssetRelocationController()

        {
            _IBranch = new Branch(new Models.FixedAssetEntities());
            _db = new Relocation(new Models.FixedAssetEntities());


        }



        public AssetRelocationController(IBranch IBranch, IRelocation db)
        {

            _IBranch = IBranch;
            _db = db;
        }



        public ActionResult locationlist()
        {
            var model = _db.GetRelocation();
            return View(model);
        }




        [HttpGet]
        public ActionResult CreateFaReloct()
        {
            var FAClass = _db.GetFAClass();
            ViewBag.FAClass = FAClass;
            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            return View();
        }
        [HttpPost]
        public ActionResult CreateFaReloct(AssetRelocationModel model)
        {


            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            var FAClass = _db.GetFAClass();
            ViewBag.FAClass = FAClass;

            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _db.CraeteAsetRelocat(model);
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
            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            var FAClass = _db.GetFAClass();
            ViewBag.FAClass = FAClass;



            var result = _db.GetFalocationId(Id);
            return View(result);
        }






        [HttpPost]
        public ActionResult Edit(AssetRelocationModel model)
        {
            var FAClass = _db.GetFAClass();
            ViewBag.FAClass = FAClass;
            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _db.UpdateAsetRelocat(model);
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
            var model = new AssetRelocationModel();
            model.UserID = "";
            model.AuthID = "";
            model.Id = Id;

            var result = _db.DeleteRelocatiom(model);
            if (result.retVal == 0)
            {
                ViewData["Message"] = result.retmsg;
                return RedirectToAction("locationlist", "AssetRelocation");
            }
            else
            {
                ViewData["Message"] = result.retmsg;
            }
            return View();
        }

    }
}