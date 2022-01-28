using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAsset.Controllers
{
    [Authorize]
    public class AssetRevaluationController : Controller
    {
        // GET: AssetRevaluation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create()
        {
            return View();
        }
    }
}