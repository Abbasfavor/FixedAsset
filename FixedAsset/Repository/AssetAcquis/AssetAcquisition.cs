using FixedAsset.Models;
using FixedAsset.Models.AssetAcuisition;
using FixedAsset.Models.HelperModel;
using FixedAsset.Repository.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.AssetAcquis
{
    public class AssetAcquisition : IAssetAcquisition
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public AssetAcquisition(FixedAssetEntities entity)
        {
            _entity = entity;
  
        }

        public ReturnModel InsFixedAsset(AssetModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsFixedAsset @CatCode,@ClassCode,@FACode,@FAName,@DepMethod,@Deprate,@LifeSpan,@LocationCode,@FACost," +
                    "@ResidualVal,@AccumDep,@LifeSpanUsed,@DepStartDate,@FAGLAccount,@FundingGL,@AccumDepGL,@ExpenseGL,@DisposalMethod,@DisposalAmt" +
                    ",@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@CatCode", model.CatCode),
                    new SqlParameter("@ClassCode", model.ClassCode),
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@FAName", model.FAName),
                    new SqlParameter("@DepMethod", model.Deprate),
                    new SqlParameter("@Deprate", model.Deprate),
                    new SqlParameter("@LifeSpan", model.LifeSpan),
                    new SqlParameter("@LocationCode", model.LocationCode),
                    new SqlParameter("@FACost", model.FACost),
                    new SqlParameter("@ResidualVal", model.ResidualVal),
                    new SqlParameter("@AccumDep", model.AccumDep),
                    new SqlParameter("@LifeSpanUsed", model.LifeSpanUsed),
                    new SqlParameter("@DepStartDate", model.DepStartDate),
                    new SqlParameter("@FAGLAccount", model.FAGLAccount),
                    new SqlParameter("@FundingGL", model.FundingGL),
                    new SqlParameter("@AccumDepGL", model.AccumDepGL),
                    new SqlParameter("@ExpenseGL", model.ExpenseGL),
                    new SqlParameter("@DisposalMethod", model.DisposalMethod),
                    new SqlParameter("@DisposalAmt", model.DisposalAmt),
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

        public ReturnModel Up_FixedAsset(AssetModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsFixedAsset @Id, @CatCode,@ClassCode,@FACode,@FAName,@DepMethod,@Deprate,@LifeSpan,@LocationCode,@FACost," +
                      "@ResidualVal,@AccumDep,@LifeSpanUsed,@DepStartDate,@FAGLAccount,@FundingGL,@AccumDepGL,@ExpenseGL,@DisposalMethod,@DisposalAmt" +
                      ",@userid,@authid,@retval output,@retmesg output",
                      new SqlParameter("@Id", model.Id),
                    new SqlParameter("@CatCode", model.CatCode),
                    new SqlParameter("@ClassCode", model.ClassCode),
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@FAName", model.FAName),
                    new SqlParameter("@DepMethod", model.Deprate),
                    new SqlParameter("@Deprate", model.Deprate),
                    new SqlParameter("@LifeSpan", model.LifeSpan),
                    new SqlParameter("@LocationCode", model.LocationCode),
                    new SqlParameter("@FACost", model.FACost),
                    new SqlParameter("@ResidualVal", model.ResidualVal),
                    new SqlParameter("@AccumDep", model.AccumDep),
                    new SqlParameter("@LifeSpanUsed", model.LifeSpanUsed),
                    new SqlParameter("@DepStartDate", model.DepStartDate),
                    new SqlParameter("@FAGLAccount", model.FAGLAccount),
                    new SqlParameter("@FundingGL", model.FundingGL),
                    new SqlParameter("@AccumDepGL", model.AccumDepGL),
                    new SqlParameter("@ExpenseGL", model.ExpenseGL),
                    new SqlParameter("@DisposalMethod", model.DisposalMethod),
                    new SqlParameter("@DisposalAmt", model.DisposalAmt),
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

        public ReturnModel Del_FixedAsset(AssetModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_RemFixedAsset @Id,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.Id),
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

        public IEnumerable<AssetModel> Get_FixedAsset()
        {
            var CatList = new List<AssetModel>();
            try
            {
                CatList = _entity.Database.SqlQuery<AssetModel>("Proc_GetFixedAsset").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public AssetModel GetFixedAssetByCode(string classcode)
        {
            var CatList = new AssetModel();
            try
            {
                CatList = _entity.Database.SqlQuery<AssetModel>("Proc_GetFixedAssetByFACode @FAcode",
                    new SqlParameter("@FAcode", classcode)).FirstOrDefault();

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
            _entity.Dispose();
        }
    }
}