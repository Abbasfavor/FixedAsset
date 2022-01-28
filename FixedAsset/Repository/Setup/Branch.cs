using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.Branch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.Setup
{
    public class Branch : IBranch
    {

        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public Branch(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_Branch(BrancModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsBranch @BranchCode,@brancname,@address1,@address2," +
                    "@phone,@email,@fax,@city,@region,@state,@country," +
                    "@cashaccountGL,@suspenseDR,@suspenseCR,@interbranchGL,@BranchType,@MBranchCode,@SBranchCode,@subbranch" +
                    ",@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@BranchCode", model.BranchCode),
                    new SqlParameter("@brancname", model.BranchName),
                    new SqlParameter("@address1", model.Address),
                    new SqlParameter("@address2", model.address2),
                    new SqlParameter("@phone", model.phone),
                    new SqlParameter("@email", model.email),
                    new SqlParameter("@fax", model.fax),
                    new SqlParameter("@city", model.City),
                    new SqlParameter("@region", model.region),
                    new SqlParameter("@state", model.State),
                    new SqlParameter("@country", model.Country),
                    new SqlParameter("@cashaccountGL", model.cashaccount),
                    new SqlParameter("@suspenseDR", model.suspenseDR),
                    new SqlParameter("@suspenseCR", model.suspenseCR),
                    new SqlParameter("@interbranchGL", model.InterBranchGL),
                    new SqlParameter("@BranchType", model.BranchType),
                    new SqlParameter("@MBranchCode", model.MBranchCode),
                    new SqlParameter("@SBranchCode", model.SBranchCode),
                    new SqlParameter("@subbranch", model.subbranch),
                    new SqlParameter("@userid", model.Userid),
                    new SqlParameter("@authid", model.authid),
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

        public ReturnModel Up_Branch(BrancModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UP_Branch @BranchCode,@brancname,@address1,@address2," +
                    "@phone,@email,@fax,@city,@region,@state,@country,@cashaccountGL,@suspenseDR,@suspenseCR,@interbranchGL,@BranchType," +
                    "@MBranchCode,@SBranchCode,@subbranch,@userid," +
                    "@authid,@retval output,@retmesg output",

                    new SqlParameter("@BranchCode", model.BranchCode),
                    new SqlParameter("@brancname", model.BranchName),
                    new SqlParameter("@address1", model.Address),
                    new SqlParameter("@address2", model.address2),
                    new SqlParameter("@phone", model.phone),
                    new SqlParameter("@email", model.email),
                    new SqlParameter("@fax", model.fax),
                    new SqlParameter("@city", model.City),
                    new SqlParameter("@region", model.region),
                    new SqlParameter("@state", model.State),
                    new SqlParameter("@country", model.Country),
                    new SqlParameter("@cashaccountGL", model.cashaccount),
                    new SqlParameter("@suspenseDR", model.suspenseDR),
                    new SqlParameter("@suspenseCR", model.suspenseCR),
                    new SqlParameter("@interbranchGL", model.InterBranchGL),
                    new SqlParameter("@BranchType", model.BranchType),
                    new SqlParameter("@MBranchCode", model.MBranchCode),
                    new SqlParameter("@SBranchCode", model.SBranchCode),
                    new SqlParameter("@subbranch", model.subbranch),
                    new SqlParameter("@userid", model.Userid),
                    new SqlParameter("@authid", model.authid),
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

        //public ReturnModel Del_FAAncilaryClass(FAAncilaryClassModel model)
        //{

        //    var retVal = new ReturnModel();
        //    SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
        //    Retval3.Direction = System.Data.ParameterDirection.Output;

        //    SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
        //    RetMsg3.Direction = System.Data.ParameterDirection.Output;
        //    try
        //    {
        //        var AppList = _entity.Database.ExecuteSqlCommand("Proc_RemFAAncillaryClass @Id,@retval output,@retmesg output",
        //            new SqlParameter("@Id", model.Id),
        //            Retval3, RetMsg3);

        //        retVal.retVal = Convert.ToInt32(Retval3.Value);
        //        retVal.retmsg = RetMsg3.Value.ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return retVal;
        //}

        public IEnumerable<BrancModel> GetBranch()
        {
            var CatList = new List<BrancModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<BrancModel>("Proc_GetBranch").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public BrancModel GetBranchByCode(string BranchCode)
        {
            var CatList = new BrancModel();
            try
            {
                CatList = _entity.Database.SqlQuery<BrancModel>("Proc_GetBranchByCode @BranchCode",
                    new SqlParameter("@BranchCode", BranchCode)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        
        public ReturnModel DeleteBranch(BrancModel model)
        {
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var datat = _entity.Database.ExecuteSqlCommand("Proc_DeleteBranch @BranchCode," +
                     "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@BranchCode", model.BranchCode),
                    new SqlParameter("@userid", model.Userid),
                    new SqlParameter("@authid", model.authid),
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
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}