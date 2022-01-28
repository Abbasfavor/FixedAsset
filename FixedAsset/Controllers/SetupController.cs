using FixedAsset.Models.Setup;
using FixedAsset.Models.Setup.AncillaryCost;
using FixedAsset.Models.Setup.Branch;
using FixedAsset.Models.Setup.Department;
using FixedAsset.Models.Setup.FAAncilaryClass;
using FixedAsset.Models.Setup.FACategory;
using FixedAsset.Models.Setup.FAClass;
using FixedAsset.Models.Setup.Role;
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
    public class SetupController : Controller
    {
        private IAncillaryCost _entity;
        private readonly IAsset_Class _asset_Class;
        private readonly IAsset_Category _IAsset_Category;
        private readonly IFALocation _IFALocation;
        private readonly IMaintenance _IMaintenance;
        private readonly IDepartment _IDepartment;
        private readonly IBranch _IBranch;
        private readonly IRole _IRole;
        private readonly IAncillaryCost _IAncillaryCost;
        private readonly IFAAncilary_Class _IFAAncilary_Class;
        public SetupController()
        {
            _entity = new AncillaryCost(new Models.FixedAssetEntities());
            _asset_Class = new Asset_Class(new Models.FixedAssetEntities());
            _IAsset_Category = new Asset_Category(new Models.FixedAssetEntities());
            _IFALocation = new FALocation(new Models.FixedAssetEntities());
            _IMaintenance = new Maintenance(new Models.FixedAssetEntities());
            _IDepartment = new Department(new Models.FixedAssetEntities());
            _IBranch = new Branch(new Models.FixedAssetEntities());
            _IRole = new Role(new Models.FixedAssetEntities());
            _IAncillaryCost = new AncillaryCost(new Models.FixedAssetEntities());
            _IFAAncilary_Class = new FAAncilary_class(new Models.FixedAssetEntities());

        }

        public SetupController(IAncillaryCost entity, IAsset_Class asset_Class, IAsset_Category IAsset_Category,
            IFALocation IFALocation, IMaintenance IMaintenance, IDepartment IDepartment, IBranch IBranch, IRole IRole, IAncillaryCost IAncillaryCost,
            IFAAncilary_Class IFAAncilary_Class)
        {
            _entity = entity;
            _asset_Class = asset_Class;
            _IAsset_Category = IAsset_Category;
            _IFALocation = IFALocation;
            _IMaintenance = IMaintenance;
            _IDepartment = IDepartment;
            _IBranch = IBranch;
            _IRole = IRole;
            _IAncillaryCost = IAncillaryCost;
            _IFAAncilary_Class = IFAAncilary_Class;
        }
        // GET: Setup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RoleList()
        {
            var model = _IRole.GetRole();
            return View(model);
        }

        public ActionResult RoleDelete(int Id)
        {
            var model = new RoleModel();
            model.role_id = Id;
            model.userid = "";
            model.authid="";
           
            var result = _IRole.DeleteRole(model);
            if (result.retVal == 0)
            {
                ViewBag.Message = String.Format("Error!!!{0}", result.retmsg);
                return RedirectToAction("RoleList", "Setup");
            }
            else {
                ViewBag.Message = String.Format("Error!!!{0}", result.retmsg);
            }
            return View(model);
        }
        public ActionResult BranchList()
        {
            var model = _IBranch.GetBranch();
            return View(model);
        }
        public ActionResult DepartmentList()
        {
            var model = _IDepartment.GetDepartment();
            return View(model);
        }
        [HttpGet]
        public ActionResult Department()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Department(DepartModel model)
        {
            model.userid = "";
            model.authid = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IDepartment.setup_Department(model);
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
        public ActionResult DepartmentEdit(string DepartId)
        {
            var result = _IDepartment.GetDeprtByCode(DepartId);
            return View(result);
        }
        [HttpPost]
        public ActionResult DepartmentEdit(DepartModel model)
        {
            model.userid = "";
            model.authid = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IDepartment.Up_Department(model);
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


        public ActionResult DepartmentDelete(string DepartId)
        {
            var model = new DepartModel();
            model.userid = "";
            model.authid = "";
            model.Deptid = DepartId;

            var result = _IDepartment.DeleteDepartment(model);
            if (result.retVal == 0)
            {
                ViewData["Message"] = result.retmsg;
                return RedirectToAction("DepartmentList", "Setup");
            }
            else
            {
                ViewData["Message"] =  result.retmsg;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Role()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Role(RoleModel model)
        {
            model.userid = "";
            model.authid = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IRole.setup_Role(model);
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
        public ActionResult RoleEdit(int? Id)
        {
            var data = _IRole.GetRoleByID(Id);
            //if (data != null)
            //{

            //}
            return View(data);
        }
        [HttpPost]
        public ActionResult RoleEdit(RoleModel model)
        {
            model.userid = "";
            model.authid = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IRole.Up_Role(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    return RedirectToAction("RoleList", "Setup");
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
        public ActionResult Depart()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Branch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Branch(BrancModel model)
        {
            model.Userid = "";
            model.authid = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IBranch.setup_Branch(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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
        public ActionResult BranchEdit(String branchCode)
        {
            var rsult = _IBranch.GetBranchByCode(branchCode);
            return View(rsult);
        }

        [HttpPost]
        public ActionResult BranchEdit(BrancModel model)
        {
            model.Userid = "";
            model.authid = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IBranch.Up_Branch(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    return RedirectToAction("BranchList", "Setup");
                }
                else
                {
                    Status = true;
                    Message = data.retmsg;
                }
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View();
        }

        public ActionResult BranchDelete(String branchCode)
        {
            var model = new BrancModel();
            model.BranchCode = branchCode;
            model.Userid = "";
            model.authid = "";

            var result = _IBranch.DeleteBranch(model);
            if (result.retVal == 0)
            {
                ViewBag.Message = String.Format("Error!!!{0}", result.retmsg);
                return RedirectToAction("BranchList", "Setup");
            }
            else
            {
                ViewBag.Message = String.Format("Error!!!{0}", result.retmsg);
            }
            return View(model);
        }

        public ActionResult AncillaryCostList()
        {
            var model = _IAncillaryCost.GetAncillaryCost();
            return View(model);
        }

        [HttpGet]
        public ActionResult create_ancillaryCost()
        {
            var getAmortize = _IMaintenance.Get_AmortiseType();
            ViewBag.getAmortize = getAmortize;

            return View();
        }
        [HttpPost]
        public ActionResult create_ancillaryCost(AncillaryCostm model)
        {
            var getAmortize = _IMaintenance.Get_AmortiseType();
            ViewBag.getAmortize = getAmortize;

            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IAncillaryCost.setup_AncillaryCost(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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
        public ActionResult AncillaryCostEdit(string CostCode)
        {
            var getAmortize = _IMaintenance.Get_AmortiseType();
            ViewBag.getAmortize = getAmortize;
            var model = _IAncillaryCost.GetAncillaryCostByCode(CostCode);
            return View(model);
        }

        [HttpPost]
        public ActionResult AncillaryCostEdit(AncillaryCostm model)
        {
            var getAmortize = _IMaintenance.Get_AmortiseType();
            ViewBag.getAmortize = getAmortize;
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IAncillaryCost.Update_AncillaryCost(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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

        public ActionResult DeleteAncillaryCost(String CostCode)
        {
            var model = new AncillaryCostm();
            model.CostCode = CostCode;
            model.UserID = "";
            model.AuthID = "";

            var result = _IAncillaryCost.DeleteAncillaryCost(model);
            if (result.retVal == 0)
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
                return RedirectToAction("AncillaryCostList", "Setup");
            }
            else
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult createAssetClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createAssetClass(FAClassModel model)
        {
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _asset_Class.setup_FAClass(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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
        public ActionResult EditAssetClass(string classcode)
        {
            var model = _asset_Class.GetClassByClassCode(classcode);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditAssetClass(FAClassModel model)
        {
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _asset_Class.Up_FAClass(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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
        public ActionResult AssetClassList()
        {
            var model = _asset_Class.GetFAClass();
            return View(model);
        }
        public ActionResult DeleteAssetClass(string classcode)
        {
            var model = new FAClassModel();
            model.ClassCode = classcode;
            model.UserID = "";
            model.AuthID = "";

            var result = _asset_Class.Del_FAClass(model);
            if (result.retVal == 0)
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
                return RedirectToAction("AssetClassList", "Setup");
            }
            else
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult createCategoryClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createCategoryClass(Asset_Categorym model)
        {
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid) {

                model.UserID = "";
                model.AuthID = "";
              
                var data = _IAsset_Category.setup_FACategory(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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

        public ActionResult CategoryClassList()
        {
            var model = _IAsset_Category.GetCategory();
            return View(model);
        }
        [HttpGet]
        public ActionResult EditCategoryClass(string CatCode)
        {
            var model = _IAsset_Category.GetCategoryById(CatCode);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditCategoryClass(Asset_Categorym model)
        {
            model.UserID = "";
            model.AuthID = "";
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                var data = _IAsset_Category.Up_FACategory(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
                }
                else
                {
                    Status = false;
                    Message = data.retmsg;
                }
                ViewBag.Message = Message;
                ViewBag.Status = Status;
            }
            return View();
        }
        public ActionResult DeleteCategoryClass(string CatCode)
        {
            var model = new Asset_Categorym();
            model.CatCode = CatCode;
            model.UserID = "";
            model.AuthID = "";

            var result = _IAsset_Category.Del_FACategory(model);
            if (result.retVal == 0)
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
                return RedirectToAction("CategoryClassList", "Setup");
            }
            else
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
            }
            return View(model);
        }
        public ActionResult AncillaryClassList()
        {
            var model = _IFAAncilary_Class.GetFAAncilaryClass();
            return View(model);
        }
        [HttpGet]
        public ActionResult createAncillaryClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createAncillaryClass(FAAncilaryClassModel model)
        {
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {

                model.UserID = "";
                model.AuthID = "";

                var data = _IFAAncilary_Class.setup_FAAncilryClass(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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
        public ActionResult EditAncillaryClass(string ClassCode)
        {
            var result = _IFAAncilary_Class.GetAncilaryClassByClassCode(ClassCode);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditAncillaryClass(FAAncilaryClassModel model)
        {
            bool Status = false;
            string Message = "";
            if (ModelState.IsValid)
            {

                model.UserID = "";
                model.AuthID = "";

                var data = _IFAAncilary_Class.Up_FAAncilaryClass(model);
                if (data.retVal == 0)
                {
                    Status = true;
                    Message = data.retmsg;
                    //return RedirectToAction("RoleList", "Setup");
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

        public ActionResult DeleteAncillaryClass(string ClassCode)
        {
            var model = new FAAncilaryClassModel();
            model.ClassCode = ClassCode;
            model.UserID = "";
            model.AuthID = "";

            var result = _IFAAncilary_Class.Del_FAAncilaryClass(model);
            if (result.retVal == 0)
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
                return RedirectToAction("AncillaryClassList", "Setup");
            }
            else
            {
                ViewBag.Message = String.Format("Error!!!{0} ", result.retmsg);
            }
            return View();
        }


    }
}