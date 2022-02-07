using FixedAsset.Models;
using FixedAsset.Models.AssetAcuisition;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.Setup.AncillaryCost;
using FixedAsset.Repository.Setup;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            var typList = new List<AncillaryCostm>();

            var retVal = new ReturnModel();
            //SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            //Retval3.Direction = System.Data.ParameterDirection.Output;

            //SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            //RetMsg3.Direction = System.Data.ParameterDirection.Output;

            string dbConnStr = ConfigurationManager.ConnectionStrings["FixedAssetEntities"].ConnectionString;
            try
            {

                using (SqlConnection con = new SqlConnection(dbConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand("proc_InsertFAAcquire"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@CatCode", model.CatCode);
                        cmd.Parameters.AddWithValue("@ClassCode", model.ClassCode);
                        cmd.Parameters.AddWithValue("@FACode", model.FACode);
                        cmd.Parameters.AddWithValue("@FAName", model.FAName);
                        cmd.Parameters.AddWithValue("@DepMethod", model.DepMethod);
                        cmd.Parameters.AddWithValue("@Deprate", model.Deprate);
                        cmd.Parameters.AddWithValue("@LifeSpan", model.LifeSpan);
                        cmd.Parameters.AddWithValue("@LocationCode", model.LocationCode);
                        cmd.Parameters.AddWithValue("@PurchaseDate", model.PurchaseDate);
                        cmd.Parameters.AddWithValue("@ExpiryDate", model.ExpiryDate);
                        cmd.Parameters.AddWithValue("@TranDate", model.TranDate);
                        cmd.Parameters.AddWithValue("@FACost", model.FACost);
                        cmd.Parameters.AddWithValue("@ResidualVal", model.ResidualVal);
                        cmd.Parameters.AddWithValue("@AccumDep", model.AccumDep);
                        cmd.Parameters.AddWithValue("@LifeSpanUsed", model.LifeSpanUsed);
                        cmd.Parameters.AddWithValue("@DepStartDate", model.DepStartDate);
                        cmd.Parameters.AddWithValue("@FAGLAccount", model.FAGLAccount);
                        cmd.Parameters.AddWithValue("@FundingGL", model.FundingGL);
                        cmd.Parameters.AddWithValue("@AccumDepGL", model.AccumDepGL);
                        cmd.Parameters.AddWithValue("@ExpenseGL", model.ExpenseGL);
                        cmd.Parameters.AddWithValue("@DisposalMethod", model.DisposalMethod);
                        cmd.Parameters.AddWithValue("@DisposalAmt", model.DisposalAmt);
                        cmd.Parameters.AddWithValue("@UserID", model.UserID);
                        cmd.Parameters.AddWithValue("@AuthID", model.AuthID);
                        SqlParameter sqlParameter = cmd.Parameters.AddWithValue("@Typ_AncCost", typList);
                        sqlParameter.SqlDbType = SqlDbType.Structured;
                        cmd.Parameters.AddWithValue("@RetVal", model.UserID).Direction=ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@retMsg", model.AuthID).Direction = ParameterDirection.Output; ;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        retVal.retVal = (int)cmd.Parameters["@RetVal"].Value;
                        retVal.retmsg = (string)cmd.Parameters["@retMsg"].Value;
                        con.Close();
                    }
                }



                //var pList = new SqlParameter("@Typ_AncCost", SqlDbType.Structured);
                //pList.TypeName = "dbo.typ_FAAncilaryCost";
                //pList.Value = typList;

                //var AppList = _entity.Database.ExecuteSqlCommand("proc_InsertFAAcquire @CatCode, @ClassCode,@FACode,@FAName,@DepMethod,@Deprate,@LifeSpan," +
                //    "@LocationCode,@PurchaseDate,@ExpiryDate,@TranDate,@FACost, @ResidualVal,@AccumDep,@LifeSpanUsed,@DepStartDate,@FAGLAccount,@FundingGL," +
                //    "@AccumDepGL,@ExpenseGL,@DisposalMethod,@DisposalAmt,@UserID,@AuthID,@Typ_AncCost," +
                //      "@RetVal output,@retMsg output",
                //      new SqlParameter("@CatCode", model.Id),
                //    new SqlParameter("@ClassCode", model.CatCode),
                //    new SqlParameter("@FACode", model.FACode),
                //    new SqlParameter("@FAName", model.FAName),
                //    new SqlParameter("@DepMethod", model.Deprate),
                //    new SqlParameter("@Deprate", model.Deprate),
                //    new SqlParameter("@LifeSpan", model.LifeSpan),
                //    new SqlParameter("@LocationCode", model.LocationCode),
                //    new SqlParameter("@PurchaseDate", model.FACost),
                //    new SqlParameter("@ExpiryDate", model.ResidualVal),
                //    new SqlParameter("@TranDate", model.AccumDep),
                //    new SqlParameter("@FACost", model.LifeSpanUsed),
                //    new SqlParameter("@ResidualVal", model.DepStartDate),
                //    new SqlParameter("@AccumDep", model.FAGLAccount),
                //    new SqlParameter("@LifeSpanUsed", model.FundingGL),
                //    new SqlParameter("@DepStartDate", model.AccumDepGL),
                //    new SqlParameter("@FAGLAccount", model.ExpenseGL),
                //    new SqlParameter("@FundingGL", model.DisposalMethod),
                //    new SqlParameter("@AccumDepGL", model.DisposalAmt),
                //    new SqlParameter("@ExpenseGL", model.DisposalAmt),
                //    new SqlParameter("@DisposalMethod", model.DisposalAmt),
                //    new SqlParameter("@DisposalAmt", model.DisposalAmt),
                //    new SqlParameter("@UserID", model.DisposalAmt),
                //    new SqlParameter("@AuthID", model.UserID),
                //    new SqlParameter("@list", SqlDbType.Structured),
                //retVal.retVal = Convert.ToInt32(Retval3.Value),
                //retVal.retmsg = RetMsg3.Value.ToString();

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