using FixedAsset.Models;
using FixedAsset.Models.HelperModel;
using FixedAsset.Models.ReAncillary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FixedAsset.Repository.ReAncillary
{
    public class ReAncillary : IReAncillary
    {

        private readonly FixedAssetEntities _db = new FixedAssetEntities();

        public ReAncillary(FixedAssetEntities entity)
        {

            _db = entity;
        }




        public IEnumerable<ReAncillaryModel> GetACillaryCost()
        {
            var CatList = new List<ReAncillaryModel>();
            try
            {
                CatList = _db.Database.SqlQuery<ReAncillaryModel>("Proc_GetFAAncilaryCostTrans").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }



        public ReturnModel CraeteAnciCost(ReAncillaryModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _db.Database.ExecuteSqlCommand("Proc_InsFARecurringCostTrans @FACode,@CostCode,@TranDate,@Tranamount,@Narration,@expMethod,@DRGL,@CRGL,@MonthlyRunRate,@NextAmortDate,@AmountPaid," +
                    "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@CostCode", model.CostCode),
                    new SqlParameter("@TranDate", model.TranDate),
                    new SqlParameter("@Tranamount", model.Amount),
                    new SqlParameter("@Narration", model.Narration),
                    new SqlParameter("@expMethod", model.ExpMethod),
                    new SqlParameter("@DRGL", model.DRAccount),
                    new SqlParameter("@CRGL", model.CRAccount),
                    new SqlParameter("@MonthlyRunRate", model.MonthlyRunRate),
                    new SqlParameter("@NextAmortDate", model.NextAmortDate),
                    new SqlParameter("@AmountPaid", model.AmountPaid),
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






        public ReturnModel UpdateAnciCost(ReAncillaryModel model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _db.Database.ExecuteSqlCommand("Proc_UpFARecurringCostTrans @Id, @FACode,@CostCode,@TranDate,@Tranamount,@Narration,@expMethod,@DRGL,@CRGL,@MonthlyRunRate,@NextAmortDate,@AmountPaid," +
                    "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@FACode", model.FACode),
                    new SqlParameter("@CostCode", model.CostCode),
                    new SqlParameter("@TranDate", model.TranDate),
                    new SqlParameter("@Tranamount", model.Amount),
                    new SqlParameter("@Narration", model.Narration),
                    new SqlParameter("@expMethod", model.ExpMethod),
                    new SqlParameter("@DRGL", model.DRAccount),
                    new SqlParameter("@CRGL", model.CRAccount),
                    new SqlParameter("@MonthlyRunRate", model.MonthlyRunRate),
                    new SqlParameter("@NextAmortDate", model.NextAmortDate),
                    new SqlParameter("@AmountPaid", model.AmountPaid),
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






        public ReAncillaryModel GetAncillaryId(int Id)
        {
            var CatList = new ReAncillaryModel();
            try
            {
                CatList = _db.Database.SqlQuery<ReAncillaryModel>("Proc_GetAncilaryId @Id",
                    new SqlParameter("@Id", Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }




        public ReturnModel DeleteAnciCost(ReAncillaryModel model)
        {
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var datat = _db.Database.ExecuteSqlCommand("Proc_DeleteFAReCostTrans @Id," +
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









        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}