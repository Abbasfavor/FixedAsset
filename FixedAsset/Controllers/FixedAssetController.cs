using FixedAsset.Models.AssetAcuisition;
using FixedAsset.Repository.AssetAcquis;
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
        public FixedAssetController()
        {
            _entity = new AssetAcquisition(new Models.FixedAssetEntities());
            _asset_Class = new Asset_Class(new Models.FixedAssetEntities());
            _IAsset_Category = new Asset_Category(new Models.FixedAssetEntities());
            _IFALocation = new FALocation(new Models.FixedAssetEntities());


        }

        public FixedAssetController(IAssetAcquisition entity, IAsset_Class asset_Class, IAsset_Category IAsset_Category, IFALocation IFALocation)
        {
            _entity = entity;
            _asset_Class = asset_Class;
            _IAsset_Category = IAsset_Category;
            _IFALocation = IFALocation;
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
            try {
                var FAClass = _asset_Class.GetFAClass();
                ViewBag.FAClass = FAClass;
                var FACatCode = _IAsset_Category.GetCategory();
                ViewBag.FACatCode = FACatCode;
                var FALocationCode = _IFALocation.GetFALocation();
                ViewBag.FALocationCode = FALocationCode;
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
      
            return View();
        }
        [HttpPost]
        public ActionResult Create(AssetModel model)
        {
            var FAClass = _asset_Class.GetFAClass();
            ViewBag.FAClass = FAClass;
            var FACatCode = _IAsset_Category.GetCategory();
            ViewBag.FAClass = FACatCode;
            var FALocationCode = _IFALocation.GetFALocation();
            ViewBag.FALocationCode = FALocationCode;
            return View();
        }
    }
}