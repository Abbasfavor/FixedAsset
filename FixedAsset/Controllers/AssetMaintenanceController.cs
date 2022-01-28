using FixedAsset.Repository.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAsset.Controllers
{
    [Authorize]
    public class AssetMaintenanceController : Controller
    {
        private IMaintenance _entity;

        public AssetMaintenanceController()
        {
            _entity = new Maintenance(new Models.FixedAssetEntities());
        }

        public AssetMaintenanceController(IMaintenance entity)
        {
            _entity = entity;
        }



        // GET: AssetMaintenance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create()
        {

            try
            {
                var Amortise = _entity.Get_AmortiseType();
                ViewBag.Amortise = Amortise;
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
    }
}