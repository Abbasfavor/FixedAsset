using FixedAsset.Models.Setup.AncillaryCost;
using FixedAsset.Models.HelperModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FixedAsset.Models;

namespace FixedAsset.Repository.Setup
{
    public class AncillaryCost : IAncillaryCost
    {
        private readonly FixedAssetEntities _entity = new FixedAssetEntities();

        public AncillaryCost(FixedAssetEntities entity)
        {

            _entity = entity;
        }

        public ReturnModel setup_AncillaryCost(AncillaryCostm model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_InsAncillaryCost @costcode,@costdesc,@capitalized" +
                    ",@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@costcode", model.CostCode),
                    new SqlParameter("@costdesc", model.CostDesc),
                    new SqlParameter("@capitalized", model.Capitalized),
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
        public ReturnModel Update_AncillaryCost(AncillaryCostm model)
        {

            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var AppList = _entity.Database.ExecuteSqlCommand("Proc_UpAncillaryCost @costcode,@costdesc,@capitalized" +
                    ",@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@costcode", model.CostCode),
                    new SqlParameter("@costdesc", model.CostDesc),
                    new SqlParameter("@capitalized", model.Capitalized),
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

        public IEnumerable<AncillaryCostm> GetAncillaryCost()
        {
            var CatList = new List<AncillaryCostm>();
            try
            {
                CatList = _entity.Database.SqlQuery<AncillaryCostm>("Proc_GetAncillaryCost").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }
        public AncillaryCostm GetAncillaryCostByCode(string CostCode)
        {
            var CatList = new AncillaryCostm();
            try
            {
                CatList = _entity.Database.SqlQuery<AncillaryCostm>("Proc_GetAncillaryCostByCode @costcode",
                    new SqlParameter("@costcode", CostCode)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CatList;
        }

        public ReturnModel DeleteAncillaryCost(AncillaryCostm model)
        {
            var retVal = new ReturnModel();
            SqlParameter Retval3 = new SqlParameter("@retval", SqlDbType.Int);
            Retval3.Direction = System.Data.ParameterDirection.Output;

            SqlParameter RetMsg3 = new SqlParameter("@retmesg", SqlDbType.VarChar, 150);
            RetMsg3.Direction = System.Data.ParameterDirection.Output;
            try
            {
                var datat = _entity.Database.ExecuteSqlCommand("Proc_DeleteAncillaryCost @costcode," +
                     "@userid,@authid,@retval output,@retmesg output",
                    new SqlParameter("@costcode", model.CostCode),
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