
using FixedAsset.Models;
using FixedAsset.Models.AssetRelocation;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Branch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.AssetRelocation
{
    public class Relocation : IRelocation
    {




        private readonly FixedAssetEntities _db = new FixedAssetEntities();

        public Relocation(FixedAssetEntities entity)
        {

            _db = entity;
        }




        public IEnumerable<AssetRelocationModel> GetRelocation()
        {
            var CatList = new List<AssetRelocationModel>();
            try
            {
                CatList = _db.Database.SqlQuery<AssetRelocationModel>("Proc_GetFAAlocation").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }




        public ReturnModel CraeteAsetRelocat(AssetRelocationModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _db.Database.ExecuteSqlCommand("Proc_InsFALocation @FACode,@FALocationCode,@DateAllocated,@Branchcode,@OffEmail,@ReceiptBy,@AssetGL,@AccumDepGL,@DepExpenseGL,@CRAccount,@DRAccount," +
                    "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@FALocationCode", model.FALocationCode),
                    new SqlParameter("@DateAllocated", model.DateAllocated),
                    new SqlParameter("@Branchcode", model.BranchCode),
                    new SqlParameter("@OffEmail ", model.OffEmail),
                    new SqlParameter("@ReceiptBy", model.ReceiptBy),
                    new SqlParameter("@AssetGL", model.AssetGL),
                    new SqlParameter("@AccumDepGL", model.AccumDepGL),
                    new SqlParameter("@DepExpenseGL", model.DepExpenseGL),
                    new SqlParameter("@CRAccount", model.CRAccount),
                    new SqlParameter("@DRAccount", model.DRAccount),                  
                    new SqlParameter("@userid", model.UserID),
                    new SqlParameter("@authid", model.AuthID),
                    Retval3, RetMsg3);

                retVal.retVal = Convert.ToInt32(Retval3.Value);
                retVal.retmsg = RetMsg3.Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }





        public ReturnModel UpdateAsetRelocat(AssetRelocationModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _db.Database.ExecuteSqlCommand("Proc_UpdateFAlocation @Id, @FACode,@FALocationCode,@DateAllocated,@Branchcode,@OffEmail,@ReceiptBy,@AssetGL,@AccumDepGL,@DepExpenseGL,@CRAccount,@DRAccount," +
                    "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@FALocationCode", model.FALocationCode),
                    new SqlParameter("@DateAllocated", model.DateAllocated),
                    new SqlParameter("@Branchcode", model.BranchCode),
                    new SqlParameter("@OffEmail ", model.OffEmail),
                    new SqlParameter("@ReceiptBy", model.ReceiptBy),
                    new SqlParameter("@AssetGL", model.AssetGL),
                    new SqlParameter("@AccumDepGL", model.AccumDepGL),
                    new SqlParameter("@DepExpenseGL", model.DepExpenseGL),
                    new SqlParameter("@CRAccount", model.CRAccount),
                    new SqlParameter("@DRAccount", model.DRAccount),
                    new SqlParameter("@userid", model.UserID),
                    new SqlParameter("@authid", model.AuthID),
                    Retval3, RetMsg3);

                retVal.retVal = Convert.ToInt32(Retval3.Value);
                retVal.retmsg = RetMsg3.Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }



        public AssetRelocationModel GetFalocationId(int Id)
        {
            var CatList = new AssetRelocationModel();
            try
            {
                CatList = _db.Database.SqlQuery<AssetRelocationModel>("Proc_GetAllocationId @Id",
                    new SqlParameter("@Id", Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }




        public ReturnModel DeleteRelocatiom(AssetRelocationModel model)
        {
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var datat = _db.Database.ExecuteSqlCommand("Proc_DeleteFAReloction @Id," +
                "@userid,@authid,@retval output,@retmesg output",
                new SqlParameter("@Id", model.Id),
                new SqlParameter("@userid", model.UserID),
                new SqlParameter("@authid", model.AuthID),
                Retval3, RetMsg3);
                retVal.retVal = Convert.ToInt32(Retval3.Value);
                retVal.retmsg = RetMsg3.Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retVal;
        }





        //public IEnumerable<BrancModel> GetBranch()
        //{
        //    var CatList = new List<BrancModel>();
        //    try
        //    {
        //        CatList = _db.Database.SqlQuery<BrancModel>("Proc_GetBranch").ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return CatList;
        //}







        public IEnumerable<AssetRelocationModel> GetFAClass()
        {
            var CatList = new List<AssetRelocationModel>();
            try
            {
                CatList = _db.Database.SqlQuery<AssetRelocationModel>("Proc_GetFAClass").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }




        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}