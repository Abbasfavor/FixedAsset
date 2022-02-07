using FixedAsset.Models.AssetAcuisition;
using FixedAsset.Repository.AssetAcquis;
using FixedAsset.Repository.Maintenance;
using FixedAsset.Repository.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAsset.Controllers
{
    [Authorize]
    public class FixedAssetController : Controller
    {
        private IAssetAcquisition _entity;
        private readonly IAsset_Class _asset_Class;
        private readonly IAsset_Category _IAsset_Category;
        private readonly IFALocation _IFALocation;
        private readonly IMaintenance _IMaintenance;
        private readonly IAncillaryCost _IAncillaryCost;
        public FixedAssetController()
        {
            _entity = new AssetAcquisition(new Models.FixedAssetEntities());
            _asset_Class = new Asset_Class(new Models.FixedAssetEntities());
            _IAsset_Category = new Asset_Category(new Models.FixedAssetEntities());
            _IMaintenance = new Maintenance(new Models.FixedAssetEntities());
            _IFALocation = new FALocation(new Models.FixedAssetEntities());
            _IAncillaryCost = new AncillaryCost(new Models.FixedAssetEntities());


        }

        public FixedAssetController(IAssetAcquisition entity, IAsset_Class asset_Class, IMaintenance IMaintenance, IAsset_Category IAsset_Category,
            IFALocation IFALocation, IAncillaryCost IAncillaryCost)
        {
            _entity = entity;
            _asset_Class = asset_Class;
            _IAsset_Category = IAsset_Category;
            _IFALocation = IFALocation;
            _IMaintenance = IMaintenance;
            _IAncillaryCost = IAncillaryCost;
        }
        // GET: FixedAsset
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFixedAsset()
        {
            var result = _entity.Get_FixedAsset();
            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No record found", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            var FAClass = _asset_Class.GetFAClass();
            ViewBag.FAClass = FAClass;
            var FACatCode = _IAsset_Category.GetCategory();
            ViewBag.FACatCode = FACatCode;
            var FALocationCode = _IFALocation.GetFALocation();
            ViewBag.FALocationCode = FALocationCode;
            var getAmortize = _IMaintenance.Get_AmortiseType();
            ViewBag.getAmortize = getAmortize;
            return View();
        }
        [HttpPost]
        public ActionResult Create(AssetModel model)
        {

            bool Status = false;
            string Message = "";
            try
            {
                var FAClass = _asset_Class.GetFAClass();
                ViewBag.FAClass = FAClass;
                var FACatCode = _IAsset_Category.GetCategory();
                ViewBag.FACatCode = FACatCode;
                var FALocationCode = _IFALocation.GetFALocation();
                ViewBag.FALocationCode = FALocationCode;
                var getAmortize = _IMaintenance.Get_AmortiseType();
                ViewBag.getAmortize = getAmortize;


                model.UserID = "";
                model.AuthID = "";

                if (ModelState.IsValid)
                {
                    var data = _entity.InsFixedAsset(model);
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



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;




            return View();
        }

        public JsonResult AncillaryCost() {
            var result = _IAncillaryCost.GetAncillaryCost();
            if (result != null) {

                return Json(result, JsonRequestBehavior.AllowGet);

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}